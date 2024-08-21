-- Products --
INSERT INTO products (id, kode, nama, gambar) VALUES (1, 'P-0001', 'Surya 16', 'qwer');
INSERT INTO products (id, kode, nama, gambar) VALUES (2, 'PRD002', 'Smartphone Y100', 'smartphone_y100.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (3, 'PRD003', 'Tablet Z500', 'tablet_z500.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (4, 'PRD004', 'Headphone ProMax', 'headphone_promax.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (5, 'PRD005', 'Smartwatch Q200', 'smartwatch_q200.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (6, 'PRD006', 'Keyboard Mechanical', 'keyboard_mechanical.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (7, 'PRD007', 'Monitor 4K Ultra', 'monitor_4k_ultra.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (8, 'PRD008', 'Gaming Mouse Xtreme', 'gaming_mouse_xtreme.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (9, 'PRD009', 'External SSD 1TB', 'external_ssd_1tb.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (10, 'PRD010', 'Wireless Charger', 'wireless_charger.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (11, 'PRD011', 'Bluetooth Speaker S300', 'bluetooth_speaker_s300.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (12, 'PRD012', 'Camera DLSR X100', 'camera_dlsr_x100.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (13, 'PRD013', 'Portable Projector Z10', 'portable_projector_z10.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (14, 'PRD014', 'Fitness Tracker F1', 'fitness_tracker_f1.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (15, 'PRD015', 'Noise Cancelling Headset', 'noise_cancelling_headset.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (16, 'PRD016', 'Smart Home Hub', 'smart_home_hub.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (17, 'PRD017', 'VR Headset 2.0', 'vr_headset_2.0.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (18, 'PRD018', 'Drone X500', 'drone_x500.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (19, 'PRD019', 'Portable Power Bank', 'portable_power_bank.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (20, 'PRD020', 'Electric Scooter M3', 'electric_scooter_m3.jpg');
INSERT INTO products (id, kode, nama, gambar) VALUES (21, 'PRD021', 'Xiaomi 11T', 'xiamoi_11t.jpg');

-- Insert Basic Units --
INSERT INTO basic_units (id, Nama) VALUES (1, 'Piece');
INSERT INTO basic_units (id, Nama) VALUES (2, 'Biji');
INSERT INTO basic_units (id, Nama) VALUES (3, 'Meter');
INSERT INTO basic_units (id, Nama) VALUES (4, 'Bungkus');

-- Insert Units --
INSERT INTO units (id, basic_unit_id, kode_satuan, nama, konversi) VALUES (1, 4, 'pck', 'Pack', 10);
INSERT INTO units (id, basic_unit_id, kode_satuan, nama, konversi) VALUES (2, 3, 'roll', 'Roll', 50);

-- Insert Cashiers

-- Insert 50 realistic dummy data into 'users' table
INSERT INTO users (nama, username, password, email, avatar, is_active) VALUES
       ('Andi Pratama', 'andi.p', '$2a$12$D0NwGxZWlBoTaTs/4rWnV.5F.EAh0/9ZizlhL6G7rXgfj3RJZ9v6C', 'andi.p@example.com', 'avatar1.png', 1),
       ('Budi Santoso', 'budi.s', '$2a$12$eVnGZ.eipwwT8L1NauP6F.qUQ0mKzYXo6u47VVy9pe5z9dCRrRm9S', 'budi.s@example.com', 'avatar2.png', 0);
       

-- Dummy Suppliers --
INSERT INTO suppliers (nama, alamat, telepon) VALUES
          ('PT. Sumber Rejeki', 'Jl. Raya Industri No. 10, Jakarta', '021-5550123'),
          ('CV. Bintang Abadi', 'Jl. Merdeka No. 45, Bandung', '022-5556789'),
          ('Toko Jaya Makmur', 'Jl. Sudirman No. 22, Surabaya', '031-5554567'),
          ('PD. Lestari Sejahtera', 'Jl. Pahlawan No. 33, Medan', '061-5557890'),
          ('Koperasi Serba Usaha', 'Jl. Veteran No. 8, Yogyakarta', '0274-5558901'),
          ('Supplier Mandiri', 'Jl. Soekarno Hatta No. 15, Semarang', '024-5551234'),
          ('PT. Agung Jaya', 'Jl. H.R. Rasuna Said No. 17, Jakarta', '021-5559876'),
          ('Toko Makmur Sentosa', 'Jl. Raya Bogor No. 55, Bogor', '0251-5554321'),
          ('CV. Sejahtera Abadi', 'Jl. Raya Taman No. 12, Palembang', '0711-5556789'),
          ('PT. Harapan Baru', 'Jl. Gajah Mada No. 25, Surabaya', '031-5551234');

-- Dummy Customers --
INSERT INTO customers (nama, alamat, telepon) VALUES
     ('Ayu Pratiwi', 'Jl. Kenanga No. 7, Jakarta', '021-5550101'),
     ('Bima Setiawan', 'Jl. Melati No. 12, Bandung', '022-5550202'),
     ('Cindy Utami', 'Jl. Cempaka No. 25, Surabaya', '031-5550303'),
     ('Dedi Hartono', 'Jl. Anggrek No. 8, Medan', '061-5550404'),
     ('Eka Sari', 'Jl. Jati No. 3, Yogyakarta', '0274-5550505'),
     ('Fauzi Rizal', 'Jl. Mawar No. 16, Semarang', '024-5550606'),
     ('Gina Lestari', 'Jl. Kamboja No. 22, Jakarta', '021-5550707'),
     ('Hadi Setyawan', 'Jl. Dahlia No. 5, Bogor', '0251-5550808'),
     ('Indah Dewi', 'Jl. Melati No. 30, Palembang', '0711-5550909'),
     ('Joko Prabowo', 'Jl. Mawar No. 18, Surabaya', '031-5551010'),
     ('Kirana Putri', 'Jl. Flamboyan No. 9, Jakarta', '021-5551122'),
     ('Lukas Wijaya', 'Jl. Kenanga No. 14, Bandung', '022-5552233'),
     ('Maya Lestari', 'Jl. Anggrek No. 6, Surabaya', '031-5553344'),
     ('Nina Agustin', 'Jl. Jati No. 4, Medan', '061-5554455'),
     ('Oka Prabowo', 'Jl. Kamboja No. 2, Yogyakarta', '0274-5555566'),
     ('Putu Sari', 'Jl. Mawar No. 20, Semarang', '024-5556677'),
     ('Qori Ramadhan', 'Jl. Melati No. 8, Bogor', '0251-5557788'),
     ('Rina Susanti', 'Jl. Kenanga No. 11, Palembang', '0711-5558899'),
     ('Sari Dewi', 'Jl. Flamboyan No. 17, Surabaya', '031-5559900'),
     ('Tari Pratiwi', 'Jl. Anggrek No. 13, Jakarta', '021-5551011'),
     ('Umi Khairunnisa', 'Jl. Melati No. 21, Bandung', '022-5552122'),
     ('Vina Amelia', 'Jl. Jati No. 2, Surabaya', '031-5553233'),
     ('Wira Saputra', 'Jl. Mawar No. 15, Medan', '061-5554344'),
     ('Xena Agustin', 'Jl. Kamboja No. 10, Yogyakarta', '0274-5555455'),
     ('Yani Sari', 'Jl. Flamboyan No. 13, Semarang', '024-5556566'),
     ('Zara Lestari', 'Jl. Kenanga No. 19, Bogor', '0251-5557677'),
     ('Adhi Nugroho', 'Jl. Melati No. 5, Palembang', '0711-5558788'),
     ('Bella Rahmawati', 'Jl. Mawar No. 9, Surabaya', '031-5559899'),
     ('Charlie Setiawan', 'Jl. Anggrek No. 7, Jakarta', '021-5551000'),
     ('Daniella Putri', 'Jl. Flamboyan No. 12, Bandung', '022-5552111'),
     ('Erik Maulana', 'Jl. Kenanga No. 4, Surabaya', '031-5553222'),
     ('Fariha Sari', 'Jl. Jati No. 19, Medan', '061-5554333'),
     ('Gani Rizky', 'Jl. Kamboja No. 6, Yogyakarta', '0274-5555444'),
     ('Hilda Rahayu', 'Jl. Melati No. 11, Semarang', '024-5556555'),
     ('Irwan Alamsyah', 'Jl. Mawar No. 20, Bogor', '0251-5557666'),
     ('Jasmine Wati', 'Jl. Anggrek No. 15, Palembang', '0711-5558777'),
     ('Kevin Wijaya', 'Jl. Flamboyan No. 8, Surabaya', '031-5559888'),
     ('Lina Maharani', 'Jl. Kenanga No. 10, Jakarta', '021-5550999'),
     ('Martha Ningsih', 'Jl. Jati No. 7, Bandung', '022-5551001');




