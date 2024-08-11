-- Tabel satuan_dasar
CREATE TABLE satuan_dasar (
    satuan_dasar_id INT PRIMARY KEY AUTO_INCREMENT,
    nama_satuan_dasar VARCHAR(100) NOT NULL
);

-- Tabel satuan_barang
CREATE TABLE satuan_barang (
    satuan_barang_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_satuan VARCHAR(50) NOT NULL,
    nama_satuan VARCHAR(100) NOT NULL,
    konversi DECIMAL(10, 2) NOT NULL,
    satuan_dasar_id INT,
    FOREIGN KEY (satuan_dasar_id) REFERENCES satuan_dasar(satuan_dasar_id)
);

-- Tabel barang
CREATE TABLE barang (
    barang_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_barang VARCHAR(50) NOT NULL,
    nama_barang VARCHAR(100) NOT NULL,
    satuan_barang_id INT NOT NULL,
    FOREIGN KEY (satuan_barang_id) REFERENCES satuan_barang(satuan_barang_id)
);

-- Tabel harga_barang
CREATE TABLE harga_barang (
    harga_barang_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_transaksi VARCHAR(50) NOT NULL,
    barang_id INT NOT NULL,
    harga DECIMAL(15, 2) NOT NULL,
    tanggal_berlaku DATE NOT NULL,
    FOREIGN KEY (barang_id) REFERENCES barang(barang_id)
);

-- Tabel stok_barang
CREATE TABLE stok_barang (
    stok_barang_id INT PRIMARY KEY AUTO_INCREMENT,
    barang_id INT NOT NULL,
    satuan_barang_id INT NOT NULL,
    jumlah DECIMAL(15, 2) NOT NULL,
    FOREIGN KEY (barang_id) REFERENCES barang(barang_id),
    FOREIGN KEY (satuan_barang_id) REFERENCES satuan_barang(satuan_barang_id)
);

-- Tabel penerimaan_barang
CREATE TABLE penerimaan_barang (
    penerimaan_barang_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_transaksi VARCHAR(50) NOT NULL,
    tanggal DATE NOT NULL,
    keterangan TEXT
);

-- Tabel detail_penerimaan
CREATE TABLE detail_penerimaan (
    detail_penerimaan_id INT PRIMARY KEY AUTO_INCREMENT,
    penerimaan_barang_id INT NOT NULL,
    barang_id INT NOT NULL,
    jumlah DECIMAL(15, 2) NOT NULL,
    satuan_barang_id INT NOT NULL,
    FOREIGN KEY (penerimaan_barang_id) REFERENCES penerimaan_barang(penerimaan_barang_id),
    FOREIGN KEY (barang_id) REFERENCES barang(barang_id),
    FOREIGN KEY (satuan_barang_id) REFERENCES satuan_barang(satuan_barang_id)
);

-- Tabel penjualan
CREATE TABLE penjualan (
    penjualan_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_transaksi VARCHAR(50) NOT NULL,
    tanggal DATE NOT NULL,
    pelanggan_id INT NOT NULL,
    kasir_id INT NOT NULL,
    total DECIMAL(15, 2) NOT NULL,
    uang_muka DECIMAL(15, 2),
    sisa_pembayaran DECIMAL(15, 2),
    jenis_pembayaran VARCHAR(50),
    keterangan TEXT,
    uang_muka_id INT,
    FOREIGN KEY (pelanggan_id) REFERENCES pelanggan(pelanggan_id),
    FOREIGN KEY (kasir_id) REFERENCES kasir(kasir_id),
    FOREIGN KEY (uang_muka_id) REFERENCES uang_muka(uang_muka_id)
);

-- Tabel detail_penjualan
CREATE TABLE detail_penjualan (
    detail_penjualan_id INT PRIMARY KEY AUTO_INCREMENT,
    penjualan_id INT NOT NULL,
    barang_id INT NOT NULL,
    jumlah DECIMAL(15, 2) NOT NULL,
    harga DECIMAL(15, 2) NOT NULL,
    satuan_barang_id INT NOT NULL,
    FOREIGN KEY (penjualan_id) REFERENCES penjualan(penjualan_id),
    FOREIGN KEY (barang_id) REFERENCES barang(barang_id),
    FOREIGN KEY (satuan_barang_id) REFERENCES satuan_barang(satuan_barang_id)
);

-- Tabel cicilan_penjualan
CREATE TABLE cicilan_penjualan (
    cicilan_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_transaksi VARCHAR(50) NOT NULL,
    penjualan_id INT NOT NULL,
    jumlah_cicilan DECIMAL(15, 2) NOT NULL,
    tanggal_pembayaran DATE NOT NULL,
    status VARCHAR(50),
    keterangan TEXT,
    FOREIGN KEY (penjualan_id) REFERENCES penjualan(penjualan_id)
);

-- Tabel jadwal_pembayaran
CREATE TABLE jadwal_pembayaran (
    jadwal_pembayaran_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_transaksi VARCHAR(50) NOT NULL,
    penjualan_id INT NOT NULL,
    nomor_cicilan INT NOT NULL,
    tanggal_jatuh_tempo DATE NOT NULL,
    jumlah_cicilan DECIMAL(15, 2) NOT NULL,
    status VARCHAR(50),
    FOREIGN KEY (penjualan_id) REFERENCES penjualan(penjualan_id)
);

-- Tabel uang_muka
CREATE TABLE uang_muka (
    uang_muka_id INT PRIMARY KEY AUTO_INCREMENT,
    kode_transaksi VARCHAR(50) NOT NULL,
    pelanggan_id INT NOT NULL,
    jumlah DECIMAL(15, 2) NOT NULL,
    tanggal_pembayaran DATE NOT NULL,
    status VARCHAR(50),
    keterangan TEXT,
    FOREIGN KEY (pelanggan_id) REFERENCES pelanggan(pelanggan_id)
);

-- Tabel pelanggan
CREATE TABLE pelanggan (
    pelanggan_id INT PRIMARY KEY AUTO_INCREMENT,
    nama_pelanggan VARCHAR(100) NOT NULL,
    alamat TEXT,
    telepon VARCHAR(50)
);

-- Tabel kasir
CREATE TABLE kasir (
    kasir_id INT PRIMARY KEY AUTO_INCREMENT,
    nama_kasir VARCHAR(100) NOT NULL,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL
);

-- Tabel supplier
CREATE TABLE supplier (
    supplier_id INT PRIMARY KEY AUTO_INCREMENT,
    nama_supplier VARCHAR(100) NOT NULL,
    alamat TEXT,
    telepon VARCHAR(50)
);

-- Tabel log_kasir
CREATE TABLE log_kasir (
    log_kasir_id INT PRIMARY KEY AUTO_INCREMENT,
    kasir_id INT NOT NULL,
    tanggal DATETIME NOT NULL,
    aktivitas TEXT NOT NULL,
    ip_address VARCHAR(50),
    FOREIGN KEY (kasir_id) REFERENCES kasir(kasir_id)
);

-- Tabel roles
CREATE TABLE roles (
    role_id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(50) NOT NULL
);

-- Tabel users
CREATE TABLE users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(role_id)
);

-- Tabel permissions
CREATE TABLE permissions (
    permission_id INT PRIMARY KEY AUTO_INCREMENT,
    permission_name VARCHAR(50) NOT NULL
);

-- Tabel role_permissions
CREATE TABLE role_permissions (
    role_permission_id INT PRIMARY KEY AUTO_INCREMENT,
    role_id INT NOT NULL,
    permission_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(role_id),
    FOREIGN KEY (permission_id) REFERENCES permissions(permission_id)
);