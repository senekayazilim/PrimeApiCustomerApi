using BirImza.Types.Shared;

namespace BirImza.CoreApiCustomerApi.Controllers
{
    public class CreateStateOnOnaylarimApiRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string Certificate { get; set; }
        /// <summary>
        /// atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
        /// </summary>
        public string SignatureType { get; set; }

        /// <summary>
        /// Enveloping:2, Enveloped:4. Değer verilmez ise 4, yani Enveloped imza atılır.
        /// </summary>
        public int? XmlSignatureType { get; set; }

        /// <summary>
        /// Enveloping imza durumunda, bu özellik, zarf içinde yer alan nesnenin Encoding (kodlama) özniteliğini içerir. Default değeri http://www.w3.org/2000/09/xmldsig#base64
        /// </summary>
        public string? EnvelopingObjectEncoding { get; set; }
        /// <summary>
        /// Enveloping imza durumunda, bu özellik, zarf içinde yer alan nesnenin MIME türü (MIME type) özniteliğini içerir. Default değeri application/pdf
        /// </summary>
        public string? EnvelopingObjectMimeType { get; set; }
    }

    public class CreateStateOnOnaylarimApiResult
    {
        /// <summary>
        /// e-İmza aracına iletilecek, e-imza state'idir.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
        /// </summary>
        public string KeyID { get; set; }
        /// <summary>
        /// Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
        /// </summary>
        public string KeySecret { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public string Error { get; set; }
    }


    public class GetFingerPrintRequest
    {
        public Guid OperationId { get; set; }
    }

    public class GetFingerPrintResult
    {
        public string FingerPrint { get; set; }
    }

    public class FinishSignRequest
    {
        /// <summary>
        /// İmza işlemi sonrası imzanın LTV'ye upgrade edilip edilmeyeceğini belirler. Belgede N imza olacaksa, 1, 2, 3 ... , N-1 inci imzalar için True, sadece son imza için False gönderilmelidir.
        /// </summary>
        public bool DontUpgradeToLtv { get; set; }

        /// <summary>
        /// e-İmza aracı tarafından imzalanmış veri
        /// </summary>
        public string SignedData { get; set; }
        /// <summary>
        /// Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
        /// </summary>
        public string KeyId { get; set; }
        /// <summary>
        /// Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
        /// </summary>
        public string KeySecret { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
        /// </summary>
        public string SignatureType { get; set; }


    }

    public class FinishSignResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }
    }

    public class MobilSignResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }
    }

    public class UploadFileResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }
    }

    public class MobileSignRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
        /// </summary>
        public string SignatureType { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        
    }

    public class MobileSignRequestV2
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
        /// </summary>
        public string SignatureType { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Sadece CADES imzalar için. Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevelForCades { get;  set; }

        /// <summary>
        /// Sadece PADES imzalar için. Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForPades? SignatureLevelForPades { get; set; }
        /// <summary>
        /// Seri imza atılacaksa, dosya üzerinde hangi imzanın üzerine imza atılacağı bilgisidir. Dosya üzerinde hiç imza yoksa boş geçilir.
        /// Dosya üzerine tek imza var ise ve o imzanın üzerine imza atılacaksa S0 gönderilir.
        /// Dosya üzerinde iki tane imza var ise ve ikinci imza üzerine imza atılacaksa S0:S0 gönderilir.
        /// Parallel imzada bu parametre yok sayılır.
        /// </summary>
        public string? SignaturePath { get; set; }
        /// <summary>
        /// İmza profilleri P1, P2, P3, P4. Şuan sadece P4 desteklenmektedir. Profil istenmiyorsa bu alan null geçilir.
        /// Olası değerler
        /// P1
        /// P2
        /// P3
        /// P4
        /// </summary>
        public string? SignatureTurkishProfile { get; set; }
        /// <summary>
        /// Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse Parallel imza atılır.
        /// Olası değerler
        /// SERIAL
        /// PARALLEL
        /// </summary>
        public string SerialOrParallel { get; set; }


        /// <summary>
        /// PADES imzada, PDF üzerine QR kod gibi alanlar ekleniyor.
        /// Örnek kullanım sırasında, daha önce imza atılmış bir PDF imzalanmak istendiğinde bu QR Kod gibi alanların eklenmesinin engellenmesi gerekir.
        /// Bu nedenle eğer IsFirstSigner false ise QR kod alanı eklenmeyecek şekilde süreç çalıştırılır
        /// </summary>
        public bool IsFirstSigner { get; set; }
    }

    public class GetSignatureListResult
    {
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }
        public IEnumerable<GetSignatureListResultItem> Signatures { get; set; }
    }

    public class GetSignatureListResultItem
    {
        public string EntityLabel { get; set; }
        public int Level { get; set; }
        public string LevelString { get; set; }
        public string SubjectRDN { get; set; }
        public bool Timestamped { get; set; }
        public string ClaimedSigningTime { get; set; }
        public string? CitizenshipNo { get;  set; }
    }
}
