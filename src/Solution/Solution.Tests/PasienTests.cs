using Solution.MedicalRecord;

namespace Solution.Tests;

[TestClass]
public class PasienTests
{
    [TestMethod]
    public void ValidasiData_DataValid_TidakLemparException()
    {
        // Arrange
        var pasien = new Pasien("John Doe", 25, "123 Main St");

        // Act & Assert
        pasien.ValidasiData(); // Tidak melempar exception, test akan pass
    }

    [TestMethod]
    [ExpectedException(typeof(DataTidakLengkapException))]
    public void ValidasiData_NamaKosong_LemparDataTidakLengkapException()
    {
        // Arrange
        var pasien = new Pasien("", 25, "123 Main St");

        // Act
        pasien.ValidasiData();
    }

    [TestMethod]
    [ExpectedException(typeof(DataTidakLengkapException))]
    public void ValidasiData_AlamatKosong_LemparDataTidakLengkapException()
    {
        // Arrange
        var pasien = new Pasien("John Doe", 25, "");

        // Act
        pasien.ValidasiData();
    }

    [TestMethod]
    [ExpectedException(typeof(DataTidakValidException))]
    public void ValidasiData_UmurNegatif_LemparDataTidakValidException()
    {
        // Arrange
        var pasien = new Pasien("John Doe", -1, "123 Main St");

        // Act
        pasien.ValidasiData();
    }

    [TestMethod]
    [ExpectedException(typeof(DataTidakValidException))]
    public void ValidasiData_UmurTerlaluTinggi_LemparDataTidakValidException()
    {
        // Arrange
        var pasien = new Pasien("John Doe", 121, "123 Main St");

        // Act
        pasien.ValidasiData();
    }
}