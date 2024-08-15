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
       ('Budi Santoso', 'budi.s', '$2a$12$eVnGZ.eipwwT8L1NauP6F.qUQ0mKzYXo6u47VVy9pe5z9dCRrRm9S', 'budi.s@example.com', 'avatar2.png', 0),
       ('Citra Dewi', 'citra.d', '$2a$12$Grl8.3npOyeQbtyRyGZk0.5P3D46RbXjT3mU4VwTcXGQ8uEX1Q8eW', 'citra.d@example.com', 'avatar3.png', 1),
       ('Dewi Saraswati', 'dewi.s', '$2a$12$KfkI3eLHXxD21/6G5Xt5D.LRGw5EpxuW0gZjA1IXek.zZP5xAGxRu', 'dewi.s@example.com', 'avatar4.png', 0),
       ('Eko Wijaya', 'eko.w', '$2a$12$N6iC5f5DwA0.fw3L0UtyEu68IvfX9U3tU9s5ITP1U54Gk/qg6kzy', 'eko.w@example.com', 'avatar5.png', 1),
       ('Fina Yuliana', 'fina.y', '$2a$12$Zm4zx/D8ywhWdXc0KlHn.e2WnXxZ.xCz9cTqScmC7sYZFF.4a0U4G', 'fina.y@example.com', 'avatar6.png', 0),
       ('Gita Putri', 'gita.p', '$2a$12$kU8Er4y.EqGiP2fl.q8y0.wXCBnXXTaGdKj.PJ9F6oRE3QXecLJJS', 'gita.p@example.com', 'avatar7.png', 1),
       ('Hadi Pranoto', 'hadi.p', '$2a$12$4M7NYI8EIB1c7SpsCZWX0.4b8bMy9EmU/8Kr3Wn1r9.xFDKzBKhIC', 'hadi.p@example.com', 'avatar8.png', 0),
       ('Ika Puspita', 'ika.p', '$2a$12$7NgkQb3cr9CwDFwP5X8B2.c.xF1Z1oVVkRlWShytYZjYo3iOVyM2y', 'ika.p@example.com', 'avatar9.png', 1),
       ('Joko Suryanto', 'joko.s', '$2a$12$R3W5t2yd5rr7k.JXGGeQxOhEoO/ttN3L5DJN6yLHLz74U3IoNVJi6', 'joko.s@example.com', 'avatar10.png', 0),
       ('Kiki Setiawan', 'kiki.s', '$2a$12$YVqV3D2RDQ2R3aSOI2E3H.uHePl2HgZgEXkXfMJrEqeiB9p.EcgXK', 'kiki.s@example.com', 'avatar11.png', 1),
       ('Lia Wulandari', 'lia.w', '$2a$12$UOC6O5ISe0D2NQ4EpFWbUehZ9HCCBf.ZzN5O3Lmo1zQ5.JK6xEqGG', 'lia.w@example.com', 'avatar12.png', 0),
       ('Maya Lestari', 'maya.l', '$2a$12$03mJ6K.4/MYZKk1q1cCpNeDo03EKgz54eIc4.7MS3Ixz1tFZSc0z2', 'maya.l@example.com', 'avatar13.png', 1),
       ('Nina Agustina', 'nina.a', '$2a$12$FTx0EuK2rwR6wNpF5De9d.zlnChpFnlW0HE6sdcuUn0Zr00BY4CPO', 'nina.a@example.com', 'avatar14.png', 0),
       ('Oka Prabowo', 'oka.p', '$2a$12$E.0rD7GeW47eYUk1bm0mHu5wT1dO9uUkSLejsw1CFNG7Gy2pQ1CE2', 'oka.p@example.com', 'avatar15.png', 1),
       ('Putu Sari', 'putu.s', '$2a$12$C2M4xEpC0tpO5w3p5oE0Q.H8dR5J08C5Xo0Be0t1AsXlkMxFwEJym', 'putu.s@example.com', 'avatar16.png', 0),
       ('Qori Ramadhan', 'qori.r', '$2a$12$2F9elH7dF8HEWy8UnxFYHuoONwJnhH2OeF1HQ9yoK9Sh2nA3NWErK', 'qori.r@example.com', 'avatar17.png', 1),
       ('Rina Susanti', 'rina.s', '$2a$12$uVHTXZ0zseJ5qEqWsU6D1A6d.0PO5p1U5X.fZxJkZyXUJ6flM3pZm', 'rina.s@example.com', 'avatar18.png', 0),
       ('Sari Dewi', 'sari.d', '$2a$12$lbD0hGVP3D54kWJKpM0zfuZ7eP6w5TzEMsWZ8Rv9HIdKo3c7fjw36', 'sari.d@example.com', 'avatar19.png', 1),
       ('Tari Pratiwi', 'tari.p', '$2a$12$2U5U1r/jzyR5LOvT1e7aeOT/tiNHZg8ICk/eM.vpt0V5leYu5G1G2W', 'tari.p@example.com', 'avatar20.png', 0),
       ('Umi Khairunnisa', 'umi.k', '$2a$12$Eb5t6.cDi2s.kIS9G5b9S.yb2CXLZV4YdKrzscD0A4PPVrP2U6xeW', 'umi.k@example.com', 'avatar21.png', 1),
       ('Vina Amelia', 'vina.a', '$2a$12$7VOGEMbI0Lp7.PdzCV2bDe70jM1Zue8Hia2xRVitFVQ3C5Z6QSPme', 'vina.a@example.com', 'avatar22.png', 0),
       ('Wira Saputra', 'wira.s', '$2a$12$1H5vLbiTLyf0sy02V9YXL.mMZB6L/ECEUdFnI0HP/oVRSel26mP2C', 'wira.s@example.com', 'avatar23.png', 1),
       ('Xena Agustin', 'xena.a', '$2a$12$eGg0Y4dLC3K8R8SeO1f1x.LKrU8DDxOCUoKf3hTGS96FVJgJ9ckwS', 'xena.a@example.com', 'avatar24.png', 0),
       ('Yani Sari', 'yani.s', '$2a$12$XIgBBN.rsp/fp1oCxkvG4eUl6Zgt5JOCb7zwD/jD9FdGq.AIF5GzK', 'yani.s@example.com', 'avatar25.png', 1),
       ('Zara Lestari', 'zara.l', '$2a$12$kJ8Z7Fz6pM1kIS4tTTQm6e/JzgV4emv5xuYmk3NBGz4TbJgFx7CkK', 'zara.l@example.com', 'avatar26.png', 0),
       ('Adhi Nugroho', 'adhi.n', '$2a$12$8Rm5o1QZb4X0qFDa09zPOOeL5bZW.UkN9GB9zq2W3yQYBnn0gMrQu', 'adhi.n@example.com', 'avatar27.png', 1),
       ('Bella Rahmawati', 'bella.r', '$2a$12$Q8FZlUJvI9WUtJ4I0TVS9OQsqO9C8s9/J/82qtxHf4Nhc1.YQ8jHK', 'bella.r@example.com', 'avatar28.png', 0),
       ('Charlie Setiawan', 'charlie.s', '$2a$12$2L.e0ltnkqEy0smEKZTJYuM/h3A1xYLx/9jWpBCs0a0kW.HnHn02S', 'charlie.s@example.com', 'avatar29.png', 1),
       ('Daniella Putri', 'daniella.p', '$2a$12$H00SYOfnh7AQwz7LHo7ImO7bOci1wYFtM0VROsfEBC9o68VnnjAu2', 'daniella.p@example.com', 'avatar30.png', 0),
       ('Erik Maulana', 'erik.m', '$2a$12$3.Zj1x7b7.oKoGv5dOL7eekT4n8Eo5s53YhQQ0.aVcFqP4V1z/yNm', 'erik.m@example.com', 'avatar31.png', 1),
       ('Fariha Sari', 'fariha.s', '$2a$12$9obyz/lJh3.B5DzY70TRM0Lug1IBfZyHhWv8HpFJ0dcKJ1rCwE4fi', 'fariha.s@example.com', 'avatar32.png', 0),
       ('Gani Rizky', 'gani.r', '$2a$12$wH0b80zwMTWfplv7TXDFmeflcfhzpfTEZpz9RYb0mR2PqkL7UqCkHS', 'gani.r@example.com', 'avatar33.png', 1),
       ('Hilda Rahayu', 'hilda.r', '$2a$12$1Ydt/OdCxu3RVx9E6U1RZOQJ0hr51IxpyRCkFjZUmPbuRsNGPCGgm', 'hilda.r@example.com', 'avatar34.png', 0),
       ('Irwan Alamsyah', 'irwan.a', '$2a$12$fyupw7N5w2HnS47wKpG9PO4VX7jSDP8fsONn/tvL6yMLrS0sYY98.', 'irwan.a@example.com', 'avatar35.png', 1),
       ('Jasmine Wati', 'jasmine.w', '$2a$12$0ymAfGTpH9f43f57AP3YhOroOayN9wR0C7CDoLsFYjWUEjz6I/XnG', 'jasmine.w@example.com', 'avatar36.png', 0),
       ('Kevin Wijaya', 'kevin.w', '$2a$12$k1pYwXz1y.D6gHFs/6HLiu5c0mQFXqQ3NkVwOVX7hTl4csd5/5W7e', 'kevin.w@example.com', 'avatar37.png', 1),
       ('Lina Maharani', 'lina.m', '$2a$12$wVxYwaN5L1Mfh2h7V9X5Te02wWPH7ECuD.jXn5Gmke4cTXX4PeAiC', 'lina.m@example.com', 'avatar38.png', 0),
       ('Martha Ningsih', 'martha.n', '$2a$12$CmZSCQMLUJpG9X2O2F/F2eU9khz7uj2G7Tl5JNUABOVTWpZ75x4dyC', 'martha.n@example.com', 'avatar39.png', 1),
       ('Nanda Putra', 'nanda.p', '$2a$12$9tN4OZlO4A.z5KAwNDiGmuNf9J/IM5nXDJhWYOcXkz6a76gR4UOKm', 'nanda.p@example.com', 'avatar40.png', 0),
       ('Odie Santosa', 'odie.s', '$2a$12$JypXvjOVW/l5o0u0yxT7bu7f/6sF6xlGeE8n6t7WeDa.YUQNUlSMO', 'odie.s@example.com', 'avatar41.png', 1),
       ('Pramudya Hadi', 'pramudya.h', '$2a$12$2ZB79gFn1D1Z9NscxMeyheXalPpOEKCS3D9hvJWCKn77BOPZZk0cK', 'pramudya.h@example.com', 'avatar42.png', 0),
       ('Qiana Yuliana', 'qiana.y', '$2a$12$XJwBAYRkbHVQ8zElV2ETp.9vRvQ3ZTuO63D/9P1ShCEv29Roxf2u.', 'qiana.y@example.com', 'avatar43.png', 1),
       ('Rizal Fahmi', 'rizal.f', '$2a$12$eV1k3E5mVqG1O1DqS.W7DOkM7..GSO29mUtnUld7yKJqDeSwbd9eq', 'rizal.f@example.com', 'avatar44.png', 0),
       ('Sabrina Nisa', 'sabrina.n', '$2a$12$V8eSvh.sRkJz0t1JDhZ2Eo6QZs76JWyDnxTS2Nz9O7Q6Z98HhI3lS', 'sabrina.n@example.com', 'avatar45.png', 1),
       ('Teguh Wibowo', 'teguh.w', '$2a$12$8uIQPTqelQmE23FwKsIfeuE14Qd85NPK9bE.Svl0YH1hbmz0Hr2cq', 'teguh.w@example.com', 'avatar46.png', 0),
       ('Uli Puspita', 'uli.p', '$2a$12$0ZAGvZm0ZEGlo/0OQxsPjOBGP9tfK3Gy7QntkAxiO1iNmN0JZZ5S6', 'uli.p@example.com', 'avatar47.png', 1),
       ('Vivi Fitria', 'vivi.f', '$2a$12$9f0V0g8SHX9P5r9A5V7mYOQ7G8GbGy/ewp4lG2k1H0QKp0.WsH8aS', 'vivi.f@example.com', 'avatar48.png', 0),
       ('Wendi Putra', 'wendi.p', '$2a$12$kJpIHqCZ/xbrF9p1jM8K5u7hD4R5S97a7vE8wUdeQyyE/7jEAC1t.', 'wendi.p@example.com', 'avatar49.png', 1),
       ('Xavi Ramadhan', 'xavi.r', '$2a$12$LxW0fs1UDGIMsUKG5O3A3O/TeHgWbD7vCNF/rqVQG7W0jQ9Uw2i8a', 'xavi.r@example.com', 'avatar50.png', 0),
       ('Yuliana Sari', 'yuliana.s', '$2a$12$R0aVc7XJWxNH3yIZ6o65QOYqLQlVzdp/xN.p9rY2E2swIIIsqZbbu', 'yuliana.s@example.com', 'avatar51.png', 1),
       ('Zeki Alif', 'zeki.a', '$2a$12$QmLCrERs6C8Xn5K8ZiKz0u4L/fX1Dfh7YsLx48TAaJ1k2XxO0CeEK', 'zeki.a@example.com', 'avatar52.png', 0),
       ('Adhi Nugroho', 'adhi.n', '$2a$12$Hn.zB.G6MEelmcPQJdd6b.r6QKOfYRm5F2w3Xpq9E4Q0Zp2jt/lN2', 'adhi.n@example.com', 'avatar53.png', 1),
       ('Bella Rahmawati', 'bella.r', '$2a$12$C8pAlzw0bWQp5J8/e1G9yOT3Ey/I0jroK/6Kb1N7E5ot7sRVxtuZi', 'bella.r@example.com', 'avatar54.png', 0),
       ('Charlie Setiawan', 'charlie.s', '$2a$12$GfDWUV.ytbVeP6x/DHVcRe3aEp6Kb6RiZCRQ7rQeR8OQ5gNq7k.O0', 'charlie.s@example.com', 'avatar55.png', 1),
       ('Daniella Putri', 'daniella.p', '$2a$12$9nZ5ROj5Zb/5XNxqV0oZyMkmkQhWuGyvTywEGIloFJpxJcb2vBvcy', 'daniella.p@example.com', 'avatar56.png', 0),
       ('Erik Maulana', 'erik.m', '$2a$12$hvDdo7XEpftkpXSXx6uowOCz.s2RZyn/1CmgyV7zKgF3fct9wrQx6', 'erik.m@example.com', 'avatar57.png', 1),
       ('Fariha Sari', 'fariha.s', '$2a$12$KwZpRa2eKfsk5UjB6BGF5u6Wu0co3d/8hrfWgUbW.8WX.tzDJd7Ai', 'fariha.s@example.com', 'avatar58.png', 0),
       ('Gani Rizky', 'gani.r', '$2a$12$K.ei/cLxzlh7UJkWvblC5G5.V5nGrmJ.eK/EJ2BQjsdq6sY6qHl12', 'gani.r@example.com', 'avatar59.png', 1),
       ('Hilda Rahayu', 'hilda.r', '$2a$12$0P.RwZUtgPa/9DP5Dmqk6E2/a.Qk4.YpWy5EB/lBqmhMT/8KiNNcu', 'hilda.r@example.com', 'avatar60.png', 0),
       ('Irwan Alamsyah', 'irwan.a', '$2a$12$QzDQ.X9pEzJcN8/nA7wR5EBoS4Jsh3fgf4wx7Jc9iHbbh40P8W2zS', 'irwan.a@example.com', 'avatar61.png', 1),
       ('Jasmine Wati', 'jasmine.w', '$2a$12$LiZGgWzFGrrMX.wKf2i6r.T0Vq0h0jT9jEbZ/NxA19B4QRMn1Gq7u', 'jasmine.w@example.com', 'avatar62.png', 0),
       ('Kevin Wijaya', 'kevin.w', '$2a$12$SbXk.q6nSSkMO8oXh.fwvu4rbxHVcID0uRHZl4nPIEXLHLlGe6p1m', 'kevin.w@example.com', 'avatar63.png', 1),
       ('Lina Maharani', 'lina.m', '$2a$12$wW5T7jxJr2LsVvqY22JH3.Jk7qIfwV98.VFpf86N6s74TeXz71hV6', 'lina.m@example.com', 'avatar64.png', 0),
       ('Martha Ningsih', 'martha.n', '$2a$12$2HLGRHz2XOTJ4u9hmjKYDObup.3dnN7JCuEXJ7u8ze68zR0pEYUm.', 'martha.n@example.com', 'avatar65.png', 1),
       ('Nanda Putra', 'nanda.p', '$2a$12$4cn0R2.i7fP7yVf.yhnLmeW0KiXzM0MSiU4b6Y5M7VR6lwK6OMD7G', 'nanda.p@example.com', 'avatar66.png', 0),
       ('Odie Santosa', 'odie.s', '$2a$12$6.JtpbQcdsXwIie27RR9We4icT9NsC2QXzPbLhbJbS7H72A0cqHGS', 'odie.s@example.com', 'avatar67.png', 1),
       ('Pramudya Hadi', 'pramudya.h', '$2a$12$SWXzUmA5.yI7rVb/I7j6p.7Wj/cJH7sV4Udm3F1D50JcJkpGTew1W', 'pramudya.h@example.com', 'avatar68.png', 0),
       ('Qiana Yuliana', 'qiana.y', '$2a$12$89qAe0Sh/GC8tHVtIYI6x.4ToW8Cz/9nM28vL2FLuKw/Z6GRGNNQ2i', 'qiana.y@example.com', 'avatar69.png', 1),
       ('Rizal Fahmi', 'rizal.f', '$2a$12$ZFxMEqpeO1U/l0WGuMQkm.6NFIZ6RuwmCBUkGZ0sQW79zKwRfu53e', 'rizal.f@example.com', 'avatar70.png', 0),
       ('Sabrina Nisa', 'sabrina.n', '$2a$12$98Q4x2OrNN82tOdcgk/g2uoJepIHeUXHJFl2ehF/RiMPyMWWjUpz2', 'sabrina.n@example.com', 'avatar71.png', 1),
       ('Teguh Wibowo', 'teguh.w', '$2a$12$xiZfhL2P0rQ6TPnDb0a4E.W5CInoylzH3os1D2jV.4KvS3Jrf6uoQ', 'teguh.w@example.com', 'avatar72.png', 0),
       ('Uli Puspita', 'uli.p', '$2a$12$N6ekCBl5vFXY77ysqGm3X6BwmGZ4phWlcZhrzj/A6UAC5KzS/ybgO', 'uli.p@example.com', 'avatar73.png', 1),
       ('Vivi Fitria', 'vivi.f', '$2a$12$MCsYUmY8ZSuGfRZK0WQQJ.jwvUmqUix3APljY39MGWzhKze/i0wI6', 'vivi.f@example.com', 'avatar74.png', 0),
       ('Wendi Putra', 'wendi.p', '$2a$12$RiOwr4VsA8l6S3Tq6EkQjO5zVnZ5qeqA4bO7lK.yXMwO0Svz32Y0O', 'wendi.p@example.com', 'avatar75.png', 1),
       ('Xavi Ramadhan', 'xavi.r', '$2a$12$yJXx3Pfrp9NteEgF3onT/eKlMC2Tifn4vgILzxy1sh0nwhSx8JwP.', 'xavi.r@example.com', 'avatar76.png', 0),
       ('Yuliana Sari', 'yuliana.s', '$2a$12$FPx6KFLl8BZ4QwnqbdEdHeTq4Dtqj7E/X13ezkEpe3Vs0KzKzU/7S', 'yuliana.s@example.com', 'avatar77.png', 1),
       ('Zeki Alif', 'zeki.a', '$2a$12$s7v8UHT1Gk4MJFnVNh.cJOQoGMqB9oPtYm/Yltiv0sg7HikSvPj6y', 'zeki.a@example.com', 'avatar78.png', 0),
       ('Adhi Nugroho', 'adhi.n', '$2a$12$Vh5IZUL7s8oQKxfSTFZcfEyz7eYwU8EP8EZ.OuG4LUc2nMfbrEqhS', 'adhi.n@example.com', 'avatar79.png', 1),
       ('Bella Rahmawati', 'bella.r', '$2a$12$OlZFC.1tWjt8gA7OLOuVDOazUBvhlO.Ni5jRkxDtDHXLMvC1zbykC', 'bella.r@example.com', 'avatar80.png', 0),
       ('Charlie Setiawan', 'charlie.s', '$2a$12$89gBLFhG1OkFDYy7ldIYveI0AK7mKwRm7cH/JJKs6aVKq/U36Y3W.', 'charlie.s@example.com', 'avatar81.png', 1),
       ('Daniella Putri', 'daniella.p', '$2a$12$FkdZr2Ira8XeRfI6qP8XTgC5ZQ5I1B7tGJXRUy59tB0fGGTdZGg9K', 'daniella.p@example.com', 'avatar82.png', 0),
       ('Erik Maulana', 'erik.m', '$2a$12$epn8owK3/kG5R.uM/Bje5uA87BLU1VBGciO5SlH0qCMmt8GQy08K6', 'erik.m@example.com', 'avatar83.png', 1),
       ('Fariha Sari', 'fariha.s', '$2a$12$yBSLL1XiY.kfLho.F1qMGD0y5n3rHsO0mE6fCQha0trXiUVIn6Q9y', 'fariha.s@example.com', 'avatar84.png', 0),
       ('Gani Rizky', 'gani.r', '$2a$12$9rYfRdM0Ak82wD1k61cD6Ge2WyLvnPbE4xWo8ZxtuRDc9Pf/x8m2G', 'gani.r@example.com', 'avatar85.png', 1),
       ('Hilda Rahayu', 'hilda.r', '$2a$12$JlLlbvW9jV2D.A97RC7DKmFsJQ9fhE5b0lR6HjmF0XxCP76oRmnd0', 'hilda.r@example.com', 'avatar86.png', 0),
       ('Irwan Alamsyah', 'irwan.a', '$2a$12$T/DhW5KAPNdRA3vs/Oxw1OZ8uCnaahm1xgC2fOt.Ax.C4tpZfaPIW', 'irwan.a@example.com', 'avatar87.png', 1),
       ('Jasmine Wati', 'jasmine.w', '$2a$12$ZnxCwSPWRE3AErMLgHAtHOqeV7u5LqzCrHY3u9w/7rRVS0KNJbPfi', 'jasmine.w@example.com', 'avatar88.png', 0),
       ('Kevin Wijaya', 'kevin.w', '$2a$12$osJIkb3MwXkjchMo1vCj2.D46DW3H37f4ixIu2F2oaDTJuDJ4y5zu', 'kevin.w@example.com', 'avatar89.png', 1),
       ('Lina Maharani', 'lina.m', '$2a$12$VZHg5hxlqL8Uy4Z1ECbu1.CrmMtFlHgNT5uHLu4ae4zz/UedWgfXm', 'lina.m@example.com', 'avatar90.png', 0),
       ('Martha Ningsih', 'martha.n', '$2a$12$UIUbiNzPzH98Ko5J3HFL.Ice5uC2hPz3VpPS7WvVtv4FnPp3bsXj6', 'martha.n@example.com', 'avatar91.png', 1),
       ('Nanda Putra', 'nanda.p', '$2a$12$E6BzVV2z4J7A1w0QsqDH2i5KPIRNBLQn0A2vU/53LQmcGsFrcL21e', 'nanda.p@example.com', 'avatar92.png', 0),
       ('Odie Santosa', 'odie.s', '$2a$12$0dAiReonh78/aF9lO9ZKhOWfh6d2bl4X9X4XuwM0RM4B/QwKLr/yC', 'odie.s@example.com', 'avatar93.png', 1),
       ('Pramudya Hadi', 'pramudya.h', '$2a$12$hFGqYr0wQNoYijZ2VukZduI6nAsiYhBN58E5glrN0FPxQirn5z2Sy', 'pramudya.h@example.com', 'avatar94.png', 0),
       ('Qiana Yuliana', 'qiana.y', '$2a$12$2/lVEqKoJ9S5hK9.yBgrsXYtE.gQp.Q7nO06JQRe9D8KtZzOqXx2', 'qiana.y@example.com', 'avatar95.png', 1),
       ('Rizal Fahmi', 'rizal.f', '$2a$12$UDmC4OC4frcUGbT7rTjcRuBoSaHQmT4wmP1ZYAE1YPu3G1ZqHTdHi', 'rizal.f@example.com', 'avatar96.png', 0),
       ('Sabrina Nisa', 'sabrina.n', '$2a$12$RTzdUbg5UjHH4iJ6/TUBzH4S3Xs2f1vDlzEXhK3hZYZhlmBYikb4m', 'sabrina.n@example.com', 'avatar97.png', 1),
       ('Teguh Wibowo', 'teguh.w', '$2a$12$6F5k9FQ7gfJ.BfTkv.7JTO.Z2YHgqCKHtvXMA8GT.vHkTFUy2FBXa', 'teguh.w@example.com', 'avatar98.png', 0),
       ('Uli Puspita', 'uli.p', '$2a$12$ILuYQ3MGx2tTS/kd05lQXe.LPnpHapOgJvXHFMmTxTjPsyue7dDQy', 'uli.p@example.com', 'avatar99.png', 1),
       ('Vivi Fitria', 'vivi.f', '$2a$12$KQXiR0kpGnQ/xNhRxaVcUubDk8IQsDFnvf.hAok7AyibI9zhRJkE2', 'vivi.f@example.com', 'avatar100.png', 0),
       ('Wendi Putra', 'wendi.p', '$2a$12$7uz.S2co19tPj9SaLMQ.Wv6K3xB2V/6Z.kTsLpx3hXqW7kqOtF/p.', 'wendi.p@example.com', 'avatar101.png', 1),
       ('Xavi Ramadhan', 'xavi.r', '$2a$12$FgT5/v99uvAiWxMzJ5c/cOiJml7J2w7nHkEY/1qYybG.Kb27k5eAm', 'xavi.r@example.com', 'avatar102.png', 0),
       ('Yuliana Sari', 'yuliana.s', '$2a$12$zQe3vHPQl.YiSxT.V7jW/S2KzZBYy3E62meVq7ifEbkeRP9oNiE2m', 'yuliana.s@example.com', 'avatar103.png', 1),
       ('Zeki Alif', 'zeki.a', '$2a$12$AsBzP6FV/6I9iJe8u/5MSeoyRW7PCL9a6NHDcFZRTFYpTci/6JZaq', 'zeki.a@example.com', 'avatar104.png', 0);


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




