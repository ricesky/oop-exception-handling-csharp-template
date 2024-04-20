using Solution.BankAccount;

namespace Solution.Tests;

[TestClass]
public class BankTests
{
    [TestMethod]
    public void TambahRekening_TambahkanRekeningValid_RekeningDitambahkan()
    {
        // Arrange
        var bank = new Bank();
        var rekening = new Rekening("123456", 10000);

        // Act
        bank.TambahRekening(rekening);

        // Assert
        var rekeningDicari = bank.CariRekening("123456");
        Assert.AreEqual(rekening, rekeningDicari);
    }

    [TestMethod]
    public void CariRekening_CariRekeningYangAda_RekeningDitemukan()
    {
        // Arrange
        var bank = new Bank();
        var rekening1 = new Rekening("123456", 10000);
        var rekening2 = new Rekening("654321", 20000);
        bank.TambahRekening(rekening1);
        bank.TambahRekening(rekening2);

        // Act
        var result = bank.CariRekening("654321");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("654321", result.GetNomorRekening());
    }


    [TestMethod]
    public void CariRekening_CariRekeningYangTidakAda_LebihRekeningTidakDitemukanException()
    {
        // Arrange
        var bank = new Bank();
        var rekening = new Rekening("123456", 10000);
        bank.TambahRekening(rekening);

        // Act & Assert
        try
        {
            bank.CariRekening("000000");
            Assert.Fail("Expected an RekeningTidakDitemukanException to be thrown");
        }
        catch (RekeningTidakDitemukanException ex)
        {
            Assert.AreEqual("Rekening tidak ditemukan!", ex.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception of type {ex.GetType().Name} caught: {ex.Message}");
        }
    }

    [TestMethod]
    [ExpectedException(typeof(SaldoTidakCukupException))]
    public void Penarikan_SaldoTidakCukup_ThrowSaldoTidakCukupException()
    {
        // Arrange
        var rekening = new Rekening("123", 5000); // Saldo awal adalah 5000

        // Act
        rekening.Penarikan(6000); // Mencoba menarik lebih dari saldo
    }

    [TestMethod]
    [ExpectedException(typeof(BatasPenarikanException))]
    public void Penarikan_MelebihiBatasPenarikan_ThrowBatasPenarikanException()
    {
        // Arrange
        var rekening = new Rekening("123", 200000); // Saldo awal cukup untuk penarikan

        // Act
        rekening.Penarikan(150000); // Mencoba menarik lebih dari batas penarikan harian
    }

    [TestMethod]
    public void Penarikan_PenarikanValid_TidakThrowException()
    {
        // Arrange
        var rekening = new Rekening("123", 200000); // Saldo awal cukup

        // Act
        rekening.Penarikan(50000); // Penarikan valid di bawah batas harian dan dalam saldo

        // Assert
        Assert.AreEqual(150000, rekening.GetSaldo()); // Verifikasi saldo berkurang sesuai penarikan
    }

    [TestMethod]
    public void GetSaldo_ReturnCurrentSaldo()
    {
        // Arrange
        var rekening = new Rekening("123", 10000); // Set saldo awal

        // Act
        var saldo = rekening.GetSaldo();

        // Assert
        Assert.AreEqual(10000, saldo); // Verifikasi saldo sama dengan yang di-set
    }
}