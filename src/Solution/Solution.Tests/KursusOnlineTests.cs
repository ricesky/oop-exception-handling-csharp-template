using Solution.OnlineCourse;

namespace Solution.Tests;

[TestClass]
public class KursusOnlineTests
{
    private KursusOnline kursusOnline;

    [TestInitialize]
    public void Setup()
    {
        kursusOnline = new KursusOnline();
    }

    [TestMethod]
    public void DaftarPeserta_PesertaMemenuhiSyarat_TambahkanKeDaftar()
    {
        // Arrange
        var peserta = new Peserta("John Doe", 22, "Sarjana");

        // Act
        kursusOnline.DaftarPeserta(peserta);

        // Assert
        var daftarPeserta = kursusOnline.GetDaftarPeserta();
        Assert.AreEqual(1, daftarPeserta.Count);
        Assert.AreEqual("John Doe", daftarPeserta[0].Nama);
    }

    [TestMethod]
    public void DaftarPeserta_UsiaTidakMemenuhiSyarat_TidakTambahkanKeDaftar()
    {
        // Arrange
        var peserta = new Peserta("John Doe", 17, "Sarjana");

        // Act
        try
        {
            kursusOnline.DaftarPeserta(peserta);
        }
        catch (UsiaTidakMemenuhiSyaratException)
        {
            // Exception is expected
        }

        // Assert
        Assert.AreEqual(0, kursusOnline.GetDaftarPeserta().Count);
    }

    [TestMethod]
    public void DaftarPeserta_PendidikanTidakMemenuhiSyarat_TidakTambahkanKeDaftar()
    {
        // Arrange
        var peserta = new Peserta("Jane Doe", 22, "SMA");

        // Act
        try
        {
            kursusOnline.DaftarPeserta(peserta);
        }
        catch (PendidikanTidakMemenuhiSyaratException)
        {
            // Exception is expected
        }

        // Assert
        Assert.AreEqual(0, kursusOnline.GetDaftarPeserta().Count);
    }
}