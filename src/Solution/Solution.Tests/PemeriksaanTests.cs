using Solution.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Tests;

[TestClass]
public class PemeriksaanTests
{
    [TestMethod]
    public void PeriksaData_DataValid_TidakLemparException()
    {
        // Arrange
        var pasien = new Pasien("John Doe", 30, "123 Main St");
        var pemeriksaan = new Pemeriksaan();

        // Act & Assert
        pemeriksaan.PeriksaData(pasien); // Tidak melempar exception, test akan pass
    }

    [TestMethod]
    [ExpectedException(typeof(DataTidakLengkapException))]
    public void PeriksaData_NamaKosong_LemparDataTidakLengkapException()
    {
        // Arrange
        var pasien = new Pasien("", 30, "123 Main St");
        var pemeriksaan = new Pemeriksaan();

        // Act
        pemeriksaan.PeriksaData(pasien);
    }

    [TestMethod]
    [ExpectedException(typeof(DataTidakValidException))]
    public void PeriksaData_UmurNegatif_LemparDataTidakValidException()
    {
        // Arrange
        var pasien = new Pasien("John Doe", -1, "123 Main St");
        var pemeriksaan = new Pemeriksaan();

        // Act
        pemeriksaan.PeriksaData(pasien);
    }
}