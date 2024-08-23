namespace IhandCashier.Bepe.Statics;

public static class FormValidation
{
     public static StackLayout ShowErrors(StackLayout stackLayout, Dictionary<string, List<string>> errors)
    {
        stackLayout.Clear();
        foreach (var er in errors)
        {
            foreach (var x in er.Value) stackLayout.Children.Add(new Label(){Text = x ?? string.Empty, TextColor = Colors.Red});
            
        }

        return stackLayout;
    }
}