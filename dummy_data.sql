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
