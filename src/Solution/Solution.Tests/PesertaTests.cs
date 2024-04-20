using Solution.OnlineCourse;

namespace Solution.Tests;

[TestClass]
public class PesertaTests
{
    [TestMethod]
    public void CekKelayakan_UsiaValidDanPendidikanValid_TidakThrowException()
    {
        // Arrange
        var peserta = new Peserta("John Doe", 22, "Sarjana");

        // Act & Assert
        peserta.CekKelayakan();
    }

    [TestMethod]
    [ExpectedException(typeof(UsiaTidakMemenuhiSyaratException))]
    public void CekKelayakan_UsiaTidakValid_ThrowUsiaTidakMemenuhiSyaratException()
    {
        // Arrange
        var peserta = new Peserta("John Doe", 17, "Sarjana");

        // Act
        peserta.CekKelayakan();
    }

    [TestMethod]
    [ExpectedException(typeof(PendidikanTidakMemenuhiSyaratException))]
    public void CekKelayakan_PendidikanTidakValid_ThrowPendidikanTidakMemenuhiSyaratException()
    {
        // Arrange
        var peserta = new Peserta("John Doe", 22, "SMA");

        // Act
        peserta.CekKelayakan();
    }
}