using Foundation;
using IhandCashier.Bepe.Interfaces;
using UIKit;

namespace IhandCashier;

public class FolderPicker : IFolderPicker
{
    private IFolderPicker _folderPickerImplementation;

    class PickerDelegate : UIDocumentPickerDelegate
    {
        public Action<NSUrl[]> PickHandler { get; set; }

        public override void WasCancelled(UIDocumentPickerViewController controller)
            => PickHandler?.Invoke(null);

        public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl[] urls)
            => PickHandler?.Invoke(urls);

        public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl url)
            => PickHandler?.Invoke(new NSUrl[] { url });
    }

    static void GetFileResults(NSUrl[] urls, TaskCompletionSource<string> tcs)
    {
        if (urls != null && urls.Length > 0)
        {
            // Assuming the first URL is the one you want
            var folderUrl = urls[0].AbsoluteString;
            tcs.TrySetResult(folderUrl);
        }
        else
        {
            tcs.TrySetResult(null);
        }
    }

    public async Task<string> PickFolder()
    {
        var allowedTypes = new string[]
        {
            "public.folder"
        };

        var picker = new UIDocumentPickerViewController(allowedTypes, UIDocumentPickerMode.Open);
        var tcs = new TaskCompletionSource<string>();

        picker.Delegate = new PickerDelegate
        {
            PickHandler = urls => GetFileResults(urls, tcs)
        };

        if (picker.PresentationController != null)
        {
            picker.PresentationController.Delegate =
                new UIPresentationControllerDelegate(() => GetFileResults(null, tcs));
        }

        var parentController = Platform.GetCurrentUIViewController();

        parentController.PresentViewController(picker, true, null);

        return await tcs.Task;
    }
    
    public Task SaveFileToFolder(string folderPath, string fileName, string content)
    {
        var fileUrl = NSUrl.FromFilename(Path.Combine(folderPath, fileName));

        NSError error;
        var success = NSData.FromString(content).Save(fileUrl, NSDataWritingOptions.Atomic, out error);

        if (!success)
        {
            Console.WriteLine($"Failed to save file: {error.LocalizedDescription}");
        }

        return Task.CompletedTask;
    }

    internal class UIPresentationControllerDelegate : UIAdaptivePresentationControllerDelegate
    {
        Action dismissHandler;

        internal UIPresentationControllerDelegate(Action dismissHandler)
            => this.dismissHandler = dismissHandler;

        public override void DidDismiss(UIPresentationController presentationController)
        {
            dismissHandler?.Invoke();
            dismissHandler = null;
        }

        protected override void Dispose(bool disposing)
        {
            dismissHandler?.Invoke();
            base.Dispose(disposing);
        }
    }
}