using FellowOakDicom;
using FellowOakDicom.Imaging.Codec;

new DicomSetupBuilder().RegisterServices(s => s.AddFellowOakDicom().AddTranscoderManager<FellowOakDicom.Imaging.NativeCodec.NativeTranscoderManager>()).SkipValidation().Build();

var tempPath = @"C:\temp\multiframe_image.dcm";
var outPath = @"C:\temp\output2.dcm";
var data = DicomFile.Open(tempPath).Dataset;

var result = new DicomFile(data).Clone(DicomTransferSyntax.JPEG2000Lossless,
    new FellowOakDicom.Imaging.NativeCodec.DicomJpeg2000Params { UpdatePhotometricInterpretation = false, ProgressionOrder = FellowOakDicom.Imaging.NativeCodec.OPJ_PROG_ORDER.RLCP });
result.Save(outPath);