# oop-exception-handling-csharp

## Sub Capaian Pembelajaran

1. Mahasiswa mampu mengimplementasikan alur tidak normal menggunakan mekanisme exception throwing.
2. Mahasiswa mampu mengimplementasikan penanganan error menggunakan konstruksi try-catch.
3. Mahasiswa mampu mengimplementasikan custom exception.

## Lingkungan Pengembangan

1. Platform: .NET 6.0
2. Bahasa: C# 10
3. IDE: Visual Studio 2022

## Cara membuka project menggunakan Visual Studio

1. Clone repositori project `oop-exception-handling-csharp` ke direktori lokal git Anda.
2. Buka Visual Studio, pilih menu File > Open > Project/Solution > Pilih file *.sln.
3. Tekan tombol Open untuk  untuk membuka solusi.
4. Baca soal dengan seksama. Buat implementasi kode sesuai dengan petunjuk.
6. Jalankan unit test di project *.Tests

> PERINGATAN: Push kode program ke remote repository jika hanya seluruh test case sudah lolos/passed (bertanda hijau).

## Soal-soal

### Soal: Pengecekan Akun Bank

Buat solusi dari soal ini di project `Solution` folder `BankAccount` dengan namespace `Solution.BankAccount`.

Sebuah bank memiliki sistem untuk mengecek saldo dan melakukan penarikan uang dari rekening pelanggan. Namun, terkadang terjadi kesalahan seperti saldo tidak mencukupi atau akun tidak ditemukan.

Buatlah kelas custom exception yang menginherit kelas `ApplicationException` sebagai berikut:
1. `SaldoTidakCukupException` yang mengembalikan pesan "Saldo tidak mencukupi!"
2. `RekeningTidakDitemukanException` yang mengembalikan pesan "Rekening tidak ditemukan!"
3. `BatasPenarikanException` yang mengembalikan pesan "Melebihi batas penarikan harian."

Buatlah kelas `Rekening` dengan variabel instance private sebagai berikut:
- `_nomor` (tipe String)
- `_saldo` (tipe double)

Kelas `Rekening` harus memiliki metode:
- `Penarikan(double jumlah)` yang mengurangi saldo dengan jumlah yang diberikan. Jika saldo tidak mencukupi, lemparkan `SaldoTidakCukupException`. Jika jumlah yang ditarik lebih dari batas penarikan harian sebesar 100000, maka lemparkan `BatasPenarikanException`. Simpan nilai batas penarikan harian dalam sebuah variabel konstan static.
- `GetSaldo()` yang mengembalikan saldo saat ini.
- `GetNomorRekening()` yang mengembalikan nomor rekening saat ini.

Buatlah kelas `Bank` dengan variabel instance berupa daftar akun (tipe List<Rekening>). Kelas `Bank` harus memiliki metode:
- `TambahRekening(Rekening rekening)` untuk menambahkan akun ke daftar.
- `CariRekening(string nomor)` untuk mencari akun berdasarkan nomor rekening. Jika rekening tidak ditemukan, lemparkan `RekeningTidakDitemukanException`.

Buatlah kelas `Program` yang didalamnya terdapat metode static `main`. Dalam metode `main`, coba tambahkan beberapa akun ke bank, lakukan penarikan, dan tangani kemungkinan exception yang mungkin terjadi.

**Catatan**: Pastikan untuk menggunakan blok try-catch untuk menangani exception yang mungkin terjadi saat menjalankan program.

### Soal: Pendaftaran Kursus Online

Buat solusi dari soal ini di project `Solution` folder `OnlineCourse` dengan namespace `Solution.OnlineCourse`.

Sebuah platform kursus online membatasi pendaftaran kursus berdasarkan usia dan tingkat pendidikan peserta. Terdapat beberapa kesalahan yang mungkin terjadi saat seseorang mencoba mendaftar. Selain itu, sistem juga mencatat setiap aktivitas pendaftaran, baik berhasil maupun gagal.

Buatlah kelas custom exception yang menginherit kelas `ApplicationException` sebagai berikut:
1. `UsiaTidakMemenuhiSyaratException` yang mengembalikan pesan "Maaf, usia Anda tidak memenuhi syarat untuk mengikuti kursus ini."
2. `PendidikanTidakMemenuhiSyaratException` yang mengembalikan pesan "Maaf, tingkat pendidikan Anda tidak memenuhi syarat untuk mengikuti kursus ini."

Buatlah kelas `Peserta` dengan variabel instance private sebagai berikut:
- `_nama` (tipe String)
- `_usia` (tipe int)
- `_tingkatPendidikan` (tipe String)

Kelas `Peserta` harus memiliki metode:
- `CekKelayakan()` yang memeriksa apakah peserta memenuhi syarat untuk mendaftar. Jika usia kurang dari 18 tahun, lemparkan `UsiaTidakMemenuhiSyaratException`. Jika tingkat pendidikan bukan "Sarjana" atau "Magister", lemparkan `PendidikanTidakMemenuhiSyaratException`.

Buatlah kelas `KursusOnline` dengan variabel instance berupa daftar peserta (tipe List<Peserta>). Kelas `KursusOnline` harus memiliki metode:
- `DaftarPeserta(Peserta peserta)` untuk menambahkan peserta ke daftar kursus setelah memeriksa kelayakannya.
- `GetDaftarPeserta()` untuk mendapatkan daftar peserta yang telah mendaftar.

Buatlah kelas `Program` yang didalamnya terdapat metode static `Main`. Dalam metode `Main`, coba daftarkan beberapa peserta ke kursus online. Tangani kemungkinan exception yang mungkin terjadi saat pendaftaran dengan blok try-catch. Di dalam blok `finally`, cetak pesan "Proses pendaftaran selesai." untuk menandakan bahwa proses pendaftaran telah selesai, baik berhasil maupun gagal.

**Catatan**: Pastikan untuk menggunakan blok try-catch-finally saat mendaftarkan peserta untuk menangani exception yang mungkin terjadi dan mencetak pesan di blok `finally`.

### Soal: Pemeriksaan Data Pasien

Buat solusi dari soal ini di project `Solution` folder `MedicalRecord` dengan namespace `Solution.MedicalRecord`.

Sebuah aplikasi kesehatan digunakan untuk memeriksa data pasien. Terdapat beberapa kesalahan yang mungkin terjadi saat seseorang mencoba memasukkan data. Selain itu, sistem juga mencatat setiap aktivitas pemeriksaan, baik berhasil maupun gagal.

Buatlah kelas custom exception yang menginherit kelas `ApplicationException` sebagai berikut:
1. `DataTidakLengkapException` yang mengembalikan pesan "Data pasien tidak lengkap."
2. `DataTidakValidException` yang mengembalikan pesan "Data yang dimasukkan tidak valid."

Buatlah kelas `Pasien` dengan variabel instance sebagai berikut:
- `_nama` (tipe String)
- `_umur` (tipe int)
- `_alamat` (tipe String)

Kelas `Pasien` harus memiliki metode:
- `ValidasiData()` yang memeriksa apakah data pasien valid. Jika nama atau alamat kosong, lemparkan `DataTidakLengkapException`. Jika umur kurang dari 0 atau lebih dari 120, lemparkan `DataTidakValidException`.

Buatlah kelas `Pemeriksaan` dengan metode:
- `PeriksaData(Pasien pasien)` yang memeriksa validitas data pasien. Jika terjadi exception saat validasi, tangkap exception tersebut dan lemparkan kembali dengan pesan yang lebih spesifik.

Buatlah kelas `Program` yang didalamnya terdapat metode static `Main`. Dalam metode `Main`, coba periksa beberapa data pasien. Tangani kemungkinan exception yang mungkin terjadi saat pemeriksaan dengan blok try-catch. Di dalam blok `catch`, cetak pesan kesalahan yang diterima dari `PeriksaData`.

**Catatan**: Pastikan untuk menggunakan blok try-catch saat memeriksa data pasien untuk menangani exception yang mungkin terjadi dan mencetak pesan kesalahan yang spesifik. Fokus pada mekanisme rethrowing exception untuk memberikan informasi yang lebih spesifik tentang kesalahan yang terjadi.



=== Selesai ===


