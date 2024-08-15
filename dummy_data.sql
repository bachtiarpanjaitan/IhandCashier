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

-- Insert 50 realistic dummy data into 'cashiers' table

INSERT INTO cashiers (nama, username, password, telepon, is_active) VALUES
                                                                        ('Andi Pratama', 'andi.p', 'A1B2C3D4E5F6', '081234567890', 1),
                                                                        ('Budi Santoso', 'budi.s', 'B2C3D4E5F6G7', '081234567891', 0),
                                                                        ('Citra Dewi', 'citra.d', 'C3D4E5F6G7H8', '081234567892', 1),
                                                                        ('Dewi Saraswati', 'dewi.s', 'D4E5F6G7H8I9', '081234567893', 0),
                                                                        ('Eko Wijaya', 'eko.w', 'E5F6G7H8I9J0', '081234567894', 1),
                                                                        ('Fina Yuliana', 'fina.y', 'F6G7H8I9J0K1', '081234567895', 0),
                                                                        ('Gita Putri', 'gita.p', 'G7H8I9J0K1L2', '081234567896', 1),
                                                                        ('Hadi Pranoto', 'hadi.p', 'H8I9J0K1L2M3', '081234567897', 0),
                                                                        ('Ika Puspita', 'ika.p', 'I9J0K1L2M3N4', '081234567898', 1),
                                                                        ('Joko Suryanto', 'joko.s', 'J0K1L2M3N4O5', '081234567899', 0),
                                                                        ('Kiki Setiawan', 'kiki.s', 'K1L2M3N4O5P6', '081234567800', 1),
                                                                        ('Lia Wulandari', 'lia.w', 'L2M3N4O5P6Q7', '081234567801', 0),
                                                                        ('Maya Lestari', 'maya.l', 'M3N4O5P6Q7R8', '081234567802', 1),
                                                                        ('Nina Agustina', 'nina.a', 'N4O5P6Q7R8S9', '081234567803', 0),
                                                                        ('Oka Prabowo', 'oka.p', 'O5P6Q7R8S9T0', '081234567804', 1),
                                                                        ('Putu Sari', 'putu.s', 'P6Q7R8S9T0U1', '081234567805', 0),
                                                                        ('Qori Ramadhan', 'qori.r', 'Q7R8S9T0U1V2', '081234567806', 1),
                                                                        ('Rina Susanti', 'rina.s', 'R8S9T0U1V2W3', '081234567807', 0),
                                                                        ('Sari Dewi', 'sari.d', 'S9T0U1V2W3X4', '081234567808', 1),
                                                                        ('Tari Pratiwi', 'tari.p', 'T0U1V2W3X4Y5', '081234567809', 0),
                                                                        ('Umi Khairunnisa', 'umi.k', 'U1V2W3X4Y5Z6', '081234567810', 1),
                                                                        ('Vina Amelia', 'vina.a', 'V2W3X4Y5Z6A7', '081234567811', 0),
                                                                        ('Wira Saputra', 'wira.s', 'W3X4Y5Z6A7B8', '081234567812', 1),
                                                                        ('Xena Agustin', 'xena.a', 'X4Y5Z6A7B8C9', '081234567813', 0),
                                                                        ('Yani Sari', 'yani.s', 'Y5Z6A7B8C9D0', '081234567814', 1),
                                                                        ('Zara Lestari', 'zara.l', 'Z6A7B8C9D0E1', '081234567815', 0),
                                                                        ('Adhi Nugroho', 'adhi.n', 'A7B8C9D0E1F2', '081234567816', 1),
                                                                        ('Bella Rahmawati', 'bella.r', 'B8C9D0E1F2G3', '081234567817', 0),
                                                                        ('Charlie Setiawan', 'charlie.s', 'C9D0E1F2G3H4', '081234567818', 1),
                                                                        ('Daniella Putri', 'daniella.p', 'D0E1F2G3H4I5', '081234567819', 0),
                                                                        ('Erik Maulana', 'erik.m', 'E1F2G3H4I5J6', '081234567820', 1),
                                                                        ('Fariha Sari', 'fariha.s', 'F2G3H4I5J6K7', '081234567821', 0),
                                                                        ('Gani Rizky', 'gani.r', 'G3H4I5J6K7L8', '081234567822', 1),
                                                                        ('Hilda Rahayu', 'hilda.r', 'H4I5J6K7L8M9', '081234567823', 0),
                                                                        ('Irwan Alamsyah', 'irwan.a', 'I5J6K7L8M9N0', '081234567824', 1),
                                                                        ('Jasmine Wati', 'jasmine.w', 'J6K7L8M9N0O1', '081234567825', 0),
                                                                        ('Kevin Wijaya', 'kevin.w', 'K7L8M9N0O1P2', '081234567826', 1),
                                                                        ('Lina Maharani', 'lina.m', 'L8M9N0O1P2Q3', '081234567827', 0),
                                                                        ('Martha Ningsih', 'martha.n', 'M9N0O1P2Q3R4', '081234567828', 1),
                                                                        ('Nanda Putra', 'nanda.p', 'N0O1P2Q3R4S5', '081234567829', 0),
                                                                        ('Odie Santosa', 'odie.s', 'O1P2Q3R4S5T6', '081234567830', 1),
                                                                        ('Pramudya Hadi', 'pramudya.h', 'P2Q3R4S5T6U7', '081234567831', 0),
                                                                        ('Qiana Yuliana', 'qiana.y', 'Q3R4S5T6U7V8', '081234567832', 1),
                                                                        ('Rizal Fahmi', 'rizal.f', 'R4S5T6U7V8W9', '081234567833', 0),
                                                                        ('Sabrina Nisa', 'sabrina.n', 'S5T6U7V8W9X0', '081234567834', 1),
                                                                        ('Teguh Wibowo', 'teguh.w', 'T6U7V8W9X0Y1', '081234567835', 0),
                                                                        ('Uli Puspita', 'uli.p', 'U7V8W9X0Y1Z2', '081234567836', 1),
                                                                        ('Vivi Fitria', 'vivi.f', 'V8W9X0Y1Z2A3', '081234567837', 0),
                                                                        ('Wendi Putra', 'wendi.p', 'W9X0Y1Z2A3B4', '081234567838', 1),
                                                                        ('Xavi Ramadhan', 'xavi.r', 'X0Y1Z2A3B4C5', '081234567839', 0),
                                                                        ('Yuliana Sari', 'yuliana.s', 'Y1Z2A3B4C5D6', '081234567840', 1),
                                                                        ('Zeki Alif', 'zeki.a', 'Z2A3B4C5D6E7', '081234567841', 0);

