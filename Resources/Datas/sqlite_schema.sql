-- Hapus tabel jika ada --
DROP TABLE IF EXISTS basic_units;
DROP TABLE IF EXISTS units;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS customers;
DROP TABLE IF EXISTS suppliers;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS product_prices;
DROP TABLE IF EXISTS product_receipts;
DROP TABLE IF EXISTS product_receipt_details;
DROP TABLE IF EXISTS product_stocks;

-- Basic Unit --
CREATE TABLE basic_units (
     id INTEGER PRIMARY KEY AUTOINCREMENT,
     nama TEXT NOT NULL
);

-- Unit --
CREATE TABLE units (
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   basic_unit_id INTEGER,
   kode_satuan TEXT NOT NULL CHECK(length(kode_satuan) <= 50),
   nama TEXT NOT NULL CHECK(length(nama) <= 100),
   konversi REAL NOT NULL,

    -- Foreign key constraint
   FOREIGN KEY (basic_unit_id) REFERENCES basic_units(id)
);

-- User --
CREATE TABLE users (
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   nama TEXT NOT NULL CHECK(length(nama) <= 100),
   username TEXT NOT NULL CHECK(length(username) <= 50),
   password TEXT NOT NULL,
   email TEXT CHECK(length(email) <= 100),
   avatar TEXT CHECK(length(avatar) <= 255),
   is_active INTEGER NOT NULL DEFAULT 1,-- SQLite uses INTEGER for boolean values
    is_admin integer NOT NULL DEFAULT 0
    
);

-- Customer --
CREATE TABLE customers (
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   nama TEXT NOT NULL,
   alamat TEXT,
   telepon TEXT
);

-- Supplier --
CREATE TABLE suppliers (
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   nama TEXT NOT NULL,
   alamat TEXT,
   telepon TEXT
);

-- Product --
CREATE TABLE products (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  kode TEXT NOT NULL,
  nama TEXT NOT NULL,
  gambar TEXT
);

-- Product Price --
CREATE TABLE product_prices (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id INTEGER NOT NULL,
    unit_id INTEGER NOT NULL,
    harga DECIMAL(18, 2) NOT NULL,
    tanggal_berlaku TEXT NOT NULL, -- SQLite tidak memiliki tipe DateTime, biasanya disimpan sebagai TEXT
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (unit_id) REFERENCES units(id)
);

-- Product Receipt --
CREATE TABLE product_receipts (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  kode_transaksi TEXT NOT NULL UNIQUE,
  supplier_id INTEGER NOT NULL,
  penerima TEXT,
  tanggal TEXT NOT NULL,          -- SQLite tidak memiliki tipe DateTime, biasanya disimpan sebagai TEXT
  created_at TEXT,               -- SQLite tidak memiliki tipe DateTime, biasanya disimpan sebagai TEXT
  updated_at TEXT,               -- SQLite tidak memiliki tipe DateTime, biasanya disimpan sebagai TEXT
  keterangan TEXT,
  FOREIGN KEY (supplier_id) REFERENCES suppliers(id)
);

-- Product Receipt Detail --
CREATE TABLE product_receipt_details (
     id INTEGER PRIMARY KEY AUTOINCREMENT,
     product_receipt_id INTEGER NOT NULL,
     product_id INTEGER NOT NULL,
     jumlah REAL NOT NULL,           -- SQLite menggunakan tipe REAL untuk angka desimal
     unit_id INTEGER NOT NULL,
     harga_satuan REAL NOT NULL,     -- SQLite menggunakan tipe REAL untuk angka desimal
     FOREIGN KEY (product_receipt_id) REFERENCES product_receipts(id),
     FOREIGN KEY (product_id) REFERENCES products(id),
     FOREIGN KEY (unit_id) REFERENCES units(id)
);

-- Product Stock --
CREATE TABLE product_stocks (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id INTEGER NOT NULL,
    unit_id INTEGER NOT NULL,
    jumlah REAL NOT NULL,           -- SQLite menggunakan tipe REAL untuk angka desimal, tidak ada tipe khusus untuk decimal(15,2)
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (unit_id) REFERENCES units(id)
);