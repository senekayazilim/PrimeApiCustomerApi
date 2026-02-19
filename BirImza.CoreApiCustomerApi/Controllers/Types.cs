using BirImza.Types;
using BirImza.Types.Shared;

namespace BirImza.CoreApiCustomerApi.Controllers
{
    public class ProxyCreateStateOnOnaylarimApiRequest
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

    public class ProxyCreateStateOnOnaylarimApiForPadesRequestV2
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class ProxyCreateStateOnOnaylarimApiForCadesRequestV2
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse Parallel imza atılır.
        /// Olası değerler
        /// SERIAL
        /// PARALLEL
        /// </summary>
        public string SerialOrParallel { get; set; }

        /// <summary>
        /// Seri imza atılacaksa, dosya üzerinde hangi imzanın üzerine imza atılacağı bilgisidir. Dosya üzerinde hiç imza yoksa boş geçilir.
        /// Dosya üzerine tek imza var ise ve o imzanın üzerine imza atılacaksa S0 gönderilir.
        /// Dosya üzerinde iki tane imza var ise ve ikinci imza üzerine imza atılacaksa S0:S0 gönderilir.
        /// Parallel imzada bu parametre yok sayılır.
        /// </summary>
        public string? SignaturePath { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

       

        /// <summary>
        /// İmza profilleri P1, P2, P3, P4. Şuan sadece P4 desteklenmektedir. Profil istenmiyorsa bu alan null geçilir.
        /// Olası değerler
        /// P1
        /// P2
        /// P3
        /// P4
        /// </summary>
        public string? SignatureTurkishProfile { get; set; }
    }

    public class ProxyCreateStateOnOnaylarimApiForXadesRequestV2
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse Parallel imza atılır.
        /// Olası değerler
        /// SERIAL
        /// PARALLEL
        /// </summary>
        public string SerialOrParallel { get; set; }

        /// <summary>
        /// Seri imza atılacaksa, dosya üzerinde hangi imzanın üzerine imza atılacağı bilgisidir. Dosya üzerinde hiç imza yoksa boş geçilir.
        /// Dosya üzerine tek imza var ise ve o imzanın üzerine imza atılacaksa S0 gönderilir.
        /// Dosya üzerinde iki tane imza var ise ve ikinci imza üzerine imza atılacaksa S0:S0 gönderilir.
        /// Parallel imzada bu parametre yok sayılır.
        /// </summary>
        public string? SignaturePath { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

       

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
        /// Enveloping veya Enveloped imza atılıp atılacağını belirler, boş geçilirse Enveloped imza atılır.
        /// Olası değerler
        /// ENVELOPING
        /// ENVELOPED
        /// </summary>
        public string EnvelopingOrEnveloped { get; set; }

        /// <summary>
        /// application/pdf gibi mimetype değeri verilir. Boş değer verilirse application/pdf kullanılır.
        /// </summary>
        public string? EnvelopingObjectMimeType { get; set; }

        /// <summary>
        /// http://www.w3.org/2000/09/xmldsig#base64 gibi değer verilir. Boş değer verilirse http://www.w3.org/2000/09/xmldsig#base64 kullanılır.
        /// </summary>
        public string? EnvelopingObjectEncoding { get; set; }
    }

    public class ProxyCreateStateOnOnaylarimApiResult
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


    public class ProxyGetFingerPrintRequest
    {
        public Guid OperationId { get; set; }
    }

    public class ProxyGetFingerPrintResult
    {
        public string FingerPrint { get; set; }
    }

    public class ProxyFinishSignRequest
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

    public class ProxyFinishSignForPadesRequestV2
    {
        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForPades? SignatureLevel { get; set; }

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
      


    }

    public class ProxyFinishSignForCadesRequestV2
    {
        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }

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



    }

    public class ProxyFinishSignForXadesRequestV2
    {
        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForXades? SignatureLevel { get; set; }

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



    }

    public class ProxyFinishSignResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public object OperationId { get;  set; }
    }

    public class ProxyMobilSignResult
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

    public class ProxyMobilSignResultV2
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }
        public Guid OperationId { get;  set; }
    }

    public class ProxyUploadFileResult
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

    public class ProxyUploadFileResultV2
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



    public class ProxyMobileSignRequest
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

    public class ProxyMobileSignRequestV2
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
        /// Sadece XADES imzalar için. Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForXades? SignatureLevelForXades { get; set; }

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
        public string? SerialOrParallel { get; set; }


        /// <summary>
        /// PADES imzada, PDF üzerine QR kod gibi alanlar ekleniyor.
        /// Örnek kullanım sırasında, daha önce imza atılmış bir PDF imzalanmak istendiğinde bu QR Kod gibi alanların eklenmesinin engellenmesi gerekir.
        /// Bu nedenle eğer IsFirstSigner false ise QR kod alanı eklenmeyecek şekilde süreç çalıştırılır
        /// </summary>
        public bool IsFirstSigner { get; set; }

        /// <summary>
        /// Enveloping veya Enveloped imza atılıp atılacağını belirler, boş geçilirse Enveloped imza atılır.
        /// Olası değerler
        /// ENVELOPING
        /// ENVELOPED
        /// </summary>
        public string EnvelopingOrEnveloped { get; set; }
    }

    public class ProxyGetSignatureListResult
    {
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }
        public IEnumerable<ProxyGetSignatureListResultItem> Signatures { get; set; }
    }

    public class ProxyGetSignatureListResultV3
    {
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }
        public IEnumerable<ProxyGetSignatureListResultItemV3> Signatures { get; set; }
    }

    public class ProxyGetSignatureListResultItem
    {
        public string EntityLabel { get; set; }
        public int Level { get; set; }
        public string LevelString { get; set; }
        public string SubjectRDN { get; set; }
        public bool Timestamped { get; set; }
        public string ClaimedSigningTime { get; set; }
        public string? CitizenshipNo { get;  set; }
        public string? XadesSignatureType { get;  set; }
    }

    public class ProxyGetSignatureListResultItemV3
    {
        public string EntityLabel { get; set; }
        public int Level { get; set; }
        public string LevelString { get; set; }
        public string SubjectRDN { get; set; }
        public bool Timestamped { get; set; }
        public string ClaimedSigningTime { get; set; }
        public string? CitizenshipNo { get; set; }
        public string? XadesSignatureType { get; set; }
        public ProxyTimestampInfoItemV3? Timestamp { get;  set; }
        public string ParentEntity { get;  set; }
        public DateTime? ClaimedSigningTimeAsTime { get;  set; }
    }

    public class ProxyTimestampInfoItemV3
    {
        public string EntityLabel { get; set; }
        public string Time { get; set; }
        public DateTime? TimeAsTime { get; set; }
    }

    public class ProxyAddVerificationInfoCoreRequest 
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
        /// </summary>
        public ProxyVerificationInfoInner VerificationInfo { get; set; }

        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
        /// </summary>
        public ProxyQrCodeInfoInner QrCodeInfo { get; set; }
    }

    public class ProxyQrCodeInfoInner
    {
        /// <summary>
        /// QR kod içinde yazacak URL bilgisidir
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Karekodun genişliğinin sayfa genişliğine oranıdır. Sayfa genişliği 1000 olan bir sayfa için width değer 0.8 verilirse, karekod genişliği 800 olur. Karekodun genişliği ve yüksekliği eşittir
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// Karekodun sayfanın solundan olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için left değer 0.1 verilirse, karekod sayfanın solundan uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Left { get; set; }
        /// <summary>
        /// Karekodun sayfanın sağından olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için right değer 0.1 verilirse, karekod sayfanın sağından uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Right { get; set; }
        /// <summary>
        /// Karekodun sayfanın üstünden olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için top değer 0.1 verilirse, karekod sayfanın üstünden uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Top { get; set; }
        /// <summary>
        /// Karekodun sayfanın altından olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için bottom değer 0.1 verilirse, karekod sayfanın altından uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Bottom { get; set; }
        // <summary>
        /// Karekodun lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir. Örnekler: "left top", "right top"
        /// </summary>
        public string TransformOrigin { get; set; }
    }

    public class ProxyVerificationInfoInner
    {
        /// <summary>
        /// Doğrulama cümlesidir. Yeni satır için \r\n değeri girilebilir. Örnek: Satır 1\r\nSatır2
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// İmzalama cümlesi kutusunun, sayfa genişliğine oranıdır. Sayfa genişliği 1000 olan bir sayfa için width değer 0.8 verilirse, doğrulama cümlesi genişliği 800 olur.
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// İmzalama cümlesi kutusunun, sayfa yüksekliğine oranıdır. Sayfa yüksekliği 1000 olan bir sayfa için height değer 0.1 verilirse, doğrulama cümlesi yüksekliği 100 olur.
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// İmzalama cümlesi kutusunun sayfanın solundan olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için left değer 0.1 verilirse, doğrulama cümlesinin sayfanın solundan uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Left { get; set; }
        /// <summary>
        /// İmzalama cümlesi kutusunun sayfanın sağından olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için right değer 0.1 verilirse, doğrulama cümlesinin sayfanın sağından uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Right { get; set; }
        /// <summary>
        /// İmzalama cümlesi kutusunun sayfanın üstünden olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için top değer 0.1 verilirse, doğrulama cümlesinin sayfanın üstünden uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Top { get; set; }
        /// <summary>
        /// İmzalama cümlesi kutusunun sayfanın altından olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için bottom değer 0.1 verilirse, doğrulama cümlesinin sayfanın altından uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Bottom { get; set; }
        // <summary>
        /// İmzalama cümlesi kutusunun lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir. Örnekler: "left top", "right top"
        /// </summary>
        public string TransformOrigin { get; set; }
    }


    /// <summary>
    /// CoreApi V2 istatistik sorgulama isteği.
    /// Çağıran API key, kendi organizasyonundaki tüm API key'lerin istatistiklerini görebilir.
    /// </summary>
    public class ProxyGetCoreApiStatsRequest 
    {
        /// <summary>
        /// Başlangıç tarihi filtresi (opsiyonel). Belirtilirse bu tarihten itibaren olan işlemler dahil edilir.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Bitiş tarihi filtresi (opsiyonel). Belirtilirse bu tarihe kadar olan işlemler dahil edilir.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// CoreApi V2 istatistik sonucu. Organizasyon geneli özet ve API key bazlı kırılım içerir.
    /// </summary>
    public class ProxyGetCoreApiStatsResult
    {
        /// <summary>
        /// Organizasyon adı
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Uygulanan başlangıç tarihi filtresi
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Uygulanan bitiş tarihi filtresi
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Organizasyon genelindeki toplam işlem sayısı
        /// </summary>
        public int TotalOperationCount { get; set; }

        /// <summary>
        /// Organizasyon genelindeki toplam hatalı işlem sayısı
        /// </summary>
        public int TotalErrorCount { get; set; }

        /// <summary>
        /// Organizasyon genelindeki toplam dosya boyutu (byte)
        /// </summary>
        public long TotalFileSizeBytes { get; set; }

        /// <summary>
        /// API key bazlı istatistik kırılımı
        /// </summary>
        public List<ProxyApiUserStatsItem> ApiUserStats { get; set; }
    }

    /// <summary>
    /// Tek bir API key (uygulama) için istatistik özeti.
    /// </summary>
    public class ProxyApiUserStatsItem
    {
        /// <summary>
        /// API kullanıcısının Id'si
        /// </summary>
        public int ApiUserId { get; set; }

        /// <summary>
        /// API kullanıcısının adı
        /// </summary>
        public string ApiUserName { get; set; }

        /// <summary>
        /// API kullanıcısının aktif olup olmadığı
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Bu API key ile yapılan toplam işlem sayısı
        /// </summary>
        public int TotalOperationCount { get; set; }

        /// <summary>
        /// Bu API key ile yapılan toplam hatalı işlem sayısı
        /// </summary>
        public int TotalErrorCount { get; set; }

        /// <summary>
        /// Bu API key ile işlenen toplam dosya boyutu (byte)
        /// </summary>
        public long TotalFileSizeBytes { get; set; }

        /// <summary>
        /// İşlem tipi bazlı detaylı kırılım
        /// </summary>
        public List<ProxyOperationTypeStatsItem> OperationDetails { get; set; }
    }

    /// <summary>
    /// Belirli bir işlem tipi için istatistik detayı.
    /// </summary>
    public class ProxyOperationTypeStatsItem
    {

        /// <summary>
        /// İşlem tipinin açıklaması (örn. "Pades İmza Başlatma")
        /// </summary>
        public string OperationTypeDescription { get; set; }

        /// <summary>
        /// Bu işlem tipindeki toplam işlem sayısı
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Bu işlem tipindeki hatalı işlem sayısı
        /// </summary>
        public int ErrorCount { get; set; }

        /// <summary>
        /// Bu işlem tipindeki toplam dosya boyutu (byte)
        /// </summary>
        public long TotalFileSizeBytes { get; set; }
    }

    /// <summary>
    /// CoreApi V2 işlem detayları sorgulama isteği.
    /// Sayfalama ve filtreleme destekler.
    /// </summary>
    public class ProxyGetCoreApiOperationsRequest
    {
        /// <summary>
        /// Başlangıç tarihi filtresi (opsiyonel)
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Bitiş tarihi filtresi (opsiyonel)
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Belirli bir API kullanıcısına ait işlemleri filtrelemek için (opsiyonel)
        /// </summary>
        public int? ApiUserId { get; set; }

        /// <summary>
        /// Belirli bir işlem tipine göre filtrelemek için (opsiyonel)
        /// </summary>
        public int? OperationType { get; set; }

        /// <summary>
        /// Sadece hatalı veya başarılı işlemleri filtrelemek için (opsiyonel). 
        /// true = sadece hatalılar, false = sadece başarılılar, null = tümü
        /// </summary>
        public bool? HasError { get; set; }

        /// <summary>
        /// Sayfa numarası (1 tabanlı). Varsayılan: 1
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Sayfa başı kayıt sayısı. Varsayılan: 50, Maksimum: 200
        /// </summary>
        public int PageSize { get; set; } = 50;
    }

    /// <summary>
    /// CoreApi V2 işlem detayları sonucu. Sayfalanmış işlem listesi içerir.
    /// </summary>
    public class ProxyGetCoreApiOperationsResult
    {
        /// <summary>
        /// Filtrelere uyan toplam kayıt sayısı
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Mevcut sayfa numarası
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Sayfa başı kayıt sayısı
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// İşlem kayıtları listesi
        /// </summary>
        public List<ProxyCoreApiOperationItem> Operations { get; set; }
    }

    /// <summary>
    /// Tek bir CoreApi V2 işlem kaydı.
    /// </summary>
    public class ProxyCoreApiOperationItem
    {
        /// <summary>
        /// İşlem kimliği (GUID)
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// API kullanıcısının Id'si
        /// </summary>
        public int ApiUserId { get; set; }

        /// <summary>
        /// API kullanıcısının adı
        /// </summary>
        public string ApiUserName { get; set; }

        /// <summary>
        /// İşlem tipi enum değeri
        /// </summary>
        public int OperationType { get; set; }

        /// <summary>
        /// İşlem tipinin açıklaması
        /// </summary>
        public string OperationTypeDescription { get; set; }

        /// <summary>
        /// İşlem tarihi
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// İşlemde hata oluşup oluşmadığı
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Hata mesajı (varsa)
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Çıktı dosyası boyutu (byte, varsa)
        /// </summary>
        public long? OutputFileSize { get; set; }
    }

    // ═══════════════════════════════════════════════════════════════
    // V4 CAdES PROXY MODELLERİ
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// V4 CAdES e-imza atma işlemi için ilk adım isteği.
    /// Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
    /// </summary>
    public class ProxyCreateStateOnOnaylarimApiForCadesRequestV4
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır (Base64 DER veya PEM).
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Önceden upload edilmiş dosyanın OperationId'sidir.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse PARALLEL imza atılır.
        /// Olası değerler: SERIAL, PARALLEL
        /// </summary>
        public string? SerialOrParallel { get; set; }

        /// <summary>
        /// Seri imzada üzerine imza atılacak imzanın EntityLabel'ı (örn: S0, S0:S0).
        /// Boş bırakılırsa son imza üzerine atılır. Parallel imzada yok sayılır.
        /// </summary>
        public string? SignaturePath { get; set; }

        /// <summary>
        /// Hedef imza seviyesi. SignStepThree'de bu seviyeye upgrade edilir.
        /// </summary>
        public SignatureLevelForCadesV4 SignatureLevel { get; set; }

        /// <summary>
        /// Türk imza profili. EPES gerektiren seviyeler için zorunlu.
        /// None veya P1: profilsiz BES tabanlı imza. P2/P3/P4: EPES tabanlı imza.
        /// </summary>
        public CadesProfileV4 Profile { get; set; }

        /// <summary>
        /// Hash algoritması. Varsayılan SHA256.
        /// </summary>
        public CadesHashAlgorithmV4 HashAlgorithm { get; set; }

        /// <summary>
        /// true ise detached imza oluşturulur (orijinal veri .cms içine gömülmez).
        /// </summary>
        public bool Detached { get; set; }

        /// <summary>
        /// Detached imzalarda: orijinal dosyanın OperationId'si.
        /// Detached imza oluşturuluyorsa zorunludur, aksi halde null/boş bırakılır.
        /// </summary>
        public Guid? OriginalFileOperationId { get; set; }
    }

    /// <summary>
    /// V4 CAdES e-imza atma işlemi için son adım isteği.
    /// İstemcinin imzaladığı veri ile imza tamamlanır.
    /// </summary>
    public class ProxyFinishSignForCadesRequestV4
    {
        /// <summary>
        /// e-İmza aracı tarafından imzalanmış veri (Base64).
        /// </summary>
        public string SignedData { get; set; }

        /// <summary>
        /// Mevcut e-imza işlemine ait ID değeridir. StepOne'dan döner.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Mevcut e-imza işlemine ait KeySecret değeridir. StepOne'dan döner.
        /// </summary>
        public string KeySecret { get; set; }

        /// <summary>
        /// StepOne'daki OperationId.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    /// <summary>
    /// V4 CAdES imzalı bir belgedeki imza bilgilerini sorgulamak için istek modeli.
    /// </summary>
    public class ProxyGetSignatureListCadesRequestV4
    {
        /// <summary>
        /// İmzaları okunacak dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Detached imzalarda: orijinal dosyanın OperationId'si (doğrulama için).
        /// Attached imzalarda null/boş bırakılır.
        /// </summary>
        public Guid? OriginalFileOperationId { get; set; }
    }

    /// <summary>
    /// V4 CAdES imza listesi sorgulamasının sonucu.
    /// </summary>
    public class ProxyGetSignatureListCadesResultV4
    {
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Dosyanın detached imza içerip içermediğini belirtir.
        /// Client bu alanı okuyarak sonraki işlemlerde (imza/upgrade) OriginalFileOperationId göndermesi gerektiğini bilir.
        /// </summary>
        public bool IsDetached { get; set; }

        /// <summary>
        /// Dosyadaki imzaların detaylı bilgileri.
        /// </summary>
        public List<ProxyCadesSignatureInfoV4> Signatures { get; set; } = new();
    }

    /// <summary>
    /// V4 CAdES imza zenginleştirme (upgrade) isteği.
    /// Mevcut imzayı daha yüksek bir seviyeye yükseltir.
    /// </summary>
    public class ProxyUpgradeCadesRequestV4
    {
        /// <summary>
        /// Upgrade edilecek dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Hedef seviye (mevcut seviyeden yüksek olmalı).
        /// </summary>
        public SignatureLevelForCadesV4 TargetLevel { get; set; }

        /// <summary>
        /// Upgrade edilecek imzanın EntityLabel'ı (örn: S0).
        /// Boş bırakılırsa ilk imza upgrade edilir.
        /// </summary>
        public string? SignaturePath { get; set; }

        /// <summary>
        /// Detached imzalarda: orijinal dosyanın OperationId'si.
        /// Attached imzalarda null/boş bırakılır.
        /// </summary>
        public Guid? OriginalFileOperationId { get; set; }
    }

    /// <summary>
    /// V4 CAdES tek bir imzanın detaylı bilgisi.
    /// </summary>
    public class ProxyCadesSignatureInfoV4
    {
        /// <summary>
        /// İmzanın etiket bilgisi (örn: S0, S0:S0).
        /// </summary>
        public string EntityLabel { get; set; }

        /// <summary>
        /// İmza seviyesi (sayısal değer).
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// İmza seviyesinin metin karşılığı (örn: BES, T, XL, A).
        /// </summary>
        public string LevelString { get; set; }

        /// <summary>
        /// İmza sahibinin RDN (Relative Distinguished Name) bilgisi.
        /// </summary>
        public string SubjectRDN { get; set; }

        /// <summary>
        /// İmza sahibinin TC kimlik numarası (varsa).
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// İmzanın zaman damgalı olup olmadığı.
        /// </summary>
        public bool Timestamped { get; set; }

        /// <summary>
        /// İmza atılma zamanı (metin formatında).
        /// </summary>
        public string? ClaimedSigningTime { get; set; }

        /// <summary>
        /// İmza atılma zamanı (DateTime formatında).
        /// </summary>
        public DateTime? ClaimedSigningTimeAsTime { get; set; }

        /// <summary>
        /// İmzanın kapsamı (scope).
        /// </summary>
        public int Scope { get; set; }

        /// <summary>
        /// Üst imzanın EntityLabel'ı (seri imzalarda).
        /// </summary>
        public string? ParentEntity { get; set; }

        /// <summary>
        /// İmza profil adı (örn: P2, P3, P4).
        /// </summary>
        public string? ProfileName { get; set; }

        /// <summary>
        /// İmza politika OID'si.
        /// </summary>
        public string? PolicyOID { get; set; }

        /// <summary>
        /// İmzada kullanılan hash algoritması.
        /// </summary>
        public string? HashAlgorithm { get; set; }

        /// <summary>
        /// İmzanın uzun vadeli doğrulama bilgisi içerip içermediği.
        /// </summary>
        public bool ContainsLongTermInfo { get; set; }

        /// <summary>
        /// Son arşiv zaman damgası zamanı (varsa).
        /// </summary>
        public string? LastArchivalTime { get; set; }

        /// <summary>
        /// Zaman damgası detay bilgisi.
        /// </summary>
        public ProxyTimestampInfoItemV4? Timestamp { get; set; }

        /// <summary>
        /// Mevcut seviyeden yapılabilecek tüm upgrade seçenekleri (örn: ["T","C","X","XL","A"]).
        /// En üst seviyede (A) boş liste döner.
        /// </summary>
        public List<string> UpgradeOptions { get; set; } = new();

        /// <summary>
        /// Profil uyumlu upgrade seçenekleri.
        /// Profil yoksa null döner.
        /// </summary>
        public List<string>? ProfileRecommendedUpgrades { get; set; }

        /// <summary>
        /// Profil dışı upgrade seçenekleri (teknik olarak mümkün ama profil uyumsuz).
        /// Profil yoksa null döner.
        /// </summary>
        public List<string>? ProfileIncompatibleUpgrades { get; set; }
    }

    /// <summary>
    /// V4 CAdES zaman damgası detay bilgisi.
    /// </summary>
    public class ProxyTimestampInfoItemV4
    {
        /// <summary>
        /// Zaman damgasının etiket bilgisi.
        /// </summary>
        public string EntityLabel { get; set; }

        /// <summary>
        /// Zaman damgası zamanı (metin formatında).
        /// </summary>
        public string? Time { get; set; }

        /// <summary>
        /// Zaman damgası zamanı (DateTime formatında).
        /// </summary>
        public DateTime? TimeAsTime { get; set; }

        /// <summary>
        /// Zaman damgası otoritesinin (TSA) adı.
        /// </summary>
        public string? TSAName { get; set; }

        /// <summary>
        /// Zaman damgasında kullanılan hash algoritması.
        /// </summary>
        public string? HashAlgorithm { get; set; }

        /// <summary>
        /// Zaman damgası tipi (sayısal değer).
        /// </summary>
        public int TimestampType { get; set; }

        /// <summary>
        /// Zaman damgası tipinin metin karşılığı.
        /// </summary>
        public string? TimestampTypeStr { get; set; }
    }

    #region PAdES V4 Proxy Types

    /// <summary>
    /// V4 PAdES e-imza atma işlemi için ilk adım isteği.
    /// Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
    /// PAdES'te detached mod ve serial/parallel kavramı yoktur.
    /// </summary>
    public class ProxyCreateStateOnOnaylarimApiForPadesRequestV4
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır (Base64 DER veya PEM).
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Önceden upload edilmiş PDF dosyasının OperationId'sidir.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Hedef imza seviyesi. SignStepThree'de bu seviyeye upgrade edilir.
        /// </summary>
        public SignatureLevelForPadesV4 SignatureLevel { get; set; }

        /// <summary>
        /// Türk imza profili. PAdES'te sadece P4 desteklenir.
        /// None: profilsiz imza. P4: EPES tabanlı imza.
        /// </summary>
        public PadesProfileV4 Profile { get; set; }

        /// <summary>
        /// Hash algoritması. Varsayılan SHA256.
        /// </summary>
        public CadesHashAlgorithmV4 HashAlgorithm { get; set; }

        /// <summary>
        /// Görsel imza widget bilgisi. null ise görünmez (invisible) imza atılır.
        /// </summary>
        public ProxySignatureWidgetInfo? SignatureWidgetInfo { get; set; }
    }

    /// <summary>
    /// V4 PAdES e-imza atma işlemi için son adım isteği.
    /// İstemcinin imzaladığı veri ile imza tamamlanır.
    /// </summary>
    public class ProxyFinishSignForPadesRequestV4
    {
        /// <summary>
        /// e-İmza aracı tarafından imzalanmış veri (Base64).
        /// </summary>
        public string SignedData { get; set; }

        /// <summary>
        /// Mevcut e-imza işlemine ait ID değeridir. StepOne'dan döner.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Mevcut e-imza işlemine ait KeySecret değeridir. StepOne'dan döner.
        /// </summary>
        public string KeySecret { get; set; }

        /// <summary>
        /// StepOne'daki OperationId.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    /// <summary>
    /// V4 PAdES imzalı bir PDF belgedeki imza bilgilerini sorgulamak için istek modeli.
    /// </summary>
    public class ProxyGetSignatureListPadesRequestV4
    {
        /// <summary>
        /// İmzaları okunacak PDF dosyasının OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    /// <summary>
    /// V4 PAdES imza listesi sorgulamasının sonucu.
    /// </summary>
    public class ProxyGetSignatureListPadesResultV4
    {
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// PDF dosyasındaki imzaların detaylı bilgileri.
        /// </summary>
        public List<ProxyPadesSignatureInfoV4> Signatures { get; set; } = new();
    }

    /// <summary>
    /// V4 PAdES imza zenginleştirme (upgrade) isteği.
    /// NOT: B-LT'ye upgrade desteklenmez. B-LT için yeni imza atılmalıdır.
    /// </summary>
    public class ProxyUpgradePadesRequestV4
    {
        /// <summary>
        /// Upgrade edilecek PDF dosyasının OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Hedef seviye. B-T veya B-LTA olabilir. B-LT desteklenmez.
        /// </summary>
        public SignatureLevelForPadesV4 TargetLevel { get; set; }

        /// <summary>
        /// Upgrade edilecek imzanın EntityLabel'ı (örn: S0).
        /// Boş bırakılırsa ilk imza upgrade edilir.
        /// </summary>
        public string? SignaturePath { get; set; }
    }

    /// <summary>
    /// V4 PAdES tek bir imzanın detaylı bilgisi.
    /// CAdES'ten farklı olarak Scope, ParentEntity ve LastArchivalTime alanları yoktur.
    /// </summary>
    public class ProxyPadesSignatureInfoV4
    {
        /// <summary>
        /// İmzanın etiket bilgisi (örn: S0).
        /// </summary>
        public string EntityLabel { get; set; }

        /// <summary>
        /// İmza seviyesi (sayısal değer).
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// İmza seviyesinin metin karşılığı (örn: B-B, B-T, B-LT, B-LTA).
        /// </summary>
        public string LevelString { get; set; }

        /// <summary>
        /// İmza sahibinin RDN (Relative Distinguished Name) bilgisi.
        /// </summary>
        public string SubjectRDN { get; set; }

        /// <summary>
        /// İmza sahibinin TC kimlik numarası (varsa).
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// İmzanın zaman damgalı olup olmadığı.
        /// </summary>
        public bool Timestamped { get; set; }

        /// <summary>
        /// İmza atılma zamanı (metin formatında).
        /// </summary>
        public string? ClaimedSigningTime { get; set; }

        /// <summary>
        /// İmza atılma zamanı (DateTime formatında).
        /// </summary>
        public DateTime? ClaimedSigningTimeAsTime { get; set; }

        /// <summary>
        /// İmza profil adı (örn: P4).
        /// </summary>
        public string? ProfileName { get; set; }

        /// <summary>
        /// İmza politika OID'si.
        /// </summary>
        public string? PolicyOID { get; set; }

        /// <summary>
        /// İmzada kullanılan hash algoritması.
        /// </summary>
        public string? HashAlgorithm { get; set; }

        /// <summary>
        /// İmzanın uzun vadeli doğrulama bilgisi içerip içermediği.
        /// </summary>
        public bool ContainsLongTermInfo { get; set; }

        /// <summary>
        /// Zaman damgası detay bilgisi.
        /// </summary>
        public ProxyTimestampInfoItemV4? Timestamp { get; set; }

        /// <summary>
        /// Mevcut seviyeden yapılabilecek upgrade seçenekleri (örn: ["B-T","B-LTA"]).
        /// NOT: B-LT'ye upgrade desteklenmez.
        /// </summary>
        public List<string> UpgradeOptions { get; set; } = new();

        /// <summary>
        /// Profil uyumlu upgrade seçenekleri. Profil yoksa null döner.
        /// </summary>
        public List<string>? ProfileRecommendedUpgrades { get; set; }

        /// <summary>
        /// Profil dışı upgrade seçenekleri. Profil yoksa null döner.
        /// </summary>
        public List<string>? ProfileIncompatibleUpgrades { get; set; }
    }

    /// <summary>
    /// PDF üzerine görsel imza widget bilgisi.
    /// Görünür imza atılmak istendiğinde konum, boyut, arka plan görseli ve metin satırları belirtilir.
    /// </summary>
    public class ProxySignatureWidgetInfo
    {
        /// <summary>
        /// İmzanın pixel olarak genişliğidir.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// İmzanın pixel olarak yüksekliğidir.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// İmzanın sayfanın solundan olan uzaklığıdır (oran olarak).
        /// Sayfa genişliği 1000 olan bir sayfa için 0.1 verilirse, uzaklık 100 olur.
        /// Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Left { get; set; }

        /// <summary>
        /// İmzanın sayfanın sağından olan uzaklığıdır (oran olarak).
        /// Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Right { get; set; }

        /// <summary>
        /// İmzanın sayfanın üstünden olan uzaklığıdır (oran olarak).
        /// Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Top { get; set; }

        /// <summary>
        /// İmzanın sayfanın altından olan uzaklığıdır (oran olarak).
        /// Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Bottom { get; set; }

        /// <summary>
        /// İmzanın lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir.
        /// Örnekler: "left top", "right top".
        /// </summary>
        public string TransformOrigin { get; set; }

        /// <summary>
        /// İmza görselinde arka plan görseli olarak kullanılacak imajın datasıdır. İmaj jpg olmalıdır.
        /// </summary>
        public byte[] ImageBytes { get; set; }

        /// <summary>
        /// İmza görselinin hangi sayfalara yerleştirileceği bilgisidir, 0'dan başlar.
        /// </summary>
        public int[] PagesToPlaceOn { get; set; }

        /// <summary>
        /// İmza görseli içerisinde yazılacak metin satırlarıdır.
        /// </summary>
        public List<ProxyLineInfo> Lines { get; set; }
    }

    /// <summary>
    /// İmza görseli içerisindeki tek bir metin satırının bilgisi.
    /// Font, renk, marjin ve metin ayarlarını içerir.
    /// </summary>
    public class ProxyLineInfo
    {
        /// <summary>
        /// Satır içerisinde yazacak ifadedir.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Satırın sol marjinidir.
        /// </summary>
        public int LeftMargin { get; set; }

        /// <summary>
        /// Satırın üst marjinidir.
        /// </summary>
        public int TopMargin { get; set; }

        /// <summary>
        /// Satırın alt marjinidir.
        /// </summary>
        public int BottomMargin { get; set; }

        /// <summary>
        /// Satırın sağ marjinidir.
        /// </summary>
        public int RightMargin { get; set; }

        /// <summary>
        /// Satırın hangi font ile yazılacağını belirler. Arial, Tahoma gibi kullanınız.
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// Satırın hangi font büyüklüğü ile yazılacağını belirler.
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        /// Satırın hangi font tipi ile yazılacağını belirler.
        /// Olası değerler: Regular, Bold, Italic, Underline, Strikeout.
        /// </summary>
        public string FontStyle { get; set; }

        /// <summary>
        /// Satırın hangi renkle yazılacağını belirler. #FF00FF gibi kullanınız.
        /// </summary>
        public string ColorHtml { get; set; }
    }

    #endregion

    #region XAdES V4 Proxy Types

    /// <summary>
    /// V4 XAdES e-imza atma işlemi için ilk adım isteği.
    /// Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
    /// </summary>
    public class ProxyCreateStateOnOnaylarimApiForXadesRequestV4
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır (Base64 DER veya PEM).
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Önceden upload edilmiş dosyanın OperationId'sidir.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Seri veya paralel imza. Boş geçilirse PARALLEL.
        /// SERIAL: Counter-sign (üst imzanın unsigned alanına).
        /// PARALLEL: Co-sign (bağımsız yeni Signature elementi).
        /// </summary>
        public string? SerialOrParallel { get; set; }

        /// <summary>
        /// Seri imzada üzerine imza atılacak imzanın EntityLabel'ı (örn: S0).
        /// Boş bırakılırsa son imza üzerine atılır. Parallel imzada yok sayılır.
        /// </summary>
        public string? SignaturePath { get; set; }

        /// <summary>
        /// Hedef imza seviyesi. XAdES seviyeleri: BES, EPES, T, XL, A (C ve X yoktur).
        /// </summary>
        public SignatureLevelForXadesV4 SignatureLevel { get; set; }

        /// <summary>
        /// Türk imza profili. None veya P1: profilsiz BES. P2/P3/P4: EPES tabanlı imza.
        /// </summary>
        public XadesProfileV4 Profile { get; set; }

        /// <summary>
        /// Hash algoritması. Varsayılan SHA256.
        /// </summary>
        public CadesHashAlgorithmV4 HashAlgorithm { get; set; }

        /// <summary>
        /// İmza modu.
        /// Enveloped: İmza XML dokümanın içine gömülür (input XML olmalı).
        /// Enveloping: Veri ds:Object elementi içine konur.
        /// Detached: İmza ayrı dosyada.
        /// </summary>
        public XadesSignatureModeV4 SignatureMode { get; set; }

        /// <summary>
        /// Detached imzalarda: orijinal dosyanın OperationId'si.
        /// Enveloped/Enveloping'de null.
        /// </summary>
        public Guid? OriginalFileOperationId { get; set; }

        /// <summary>
        /// Enveloped modda çoklu imza için: XML'deki hedef elementin Id attribute'u.
        /// Örn: "content-1" → Reference URI="#content-1" olur.
        /// Boş ise URI="" ile tüm doküman imzalanır.
        /// </summary>
        public string? EnvelopedContentElementId { get; set; }

        /// <summary>
        /// Enveloping imza durumunda, zarf içinde yer alan nesnenin MIME türü.
        /// Boş bırakılırsa "text/xml" kullanılır.
        /// Örnek değerler: "text/xml", "application/pdf", "application/octet-stream"
        /// </summary>
        public string? EnvelopingObjectMimeType { get; set; }

        /// <summary>
        /// Enveloping imza durumunda, zarf içinde yer alan nesnenin Encoding özniteliği.
        /// Boş bırakılırsa "http://www.w3.org/2000/09/xmldsig#base64" kullanılır.
        /// </summary>
        public string? EnvelopingObjectEncoding { get; set; }
    }

    /// <summary>
    /// V4 XAdES e-imza atma işlemi için son adım isteği.
    /// İstemcinin imzaladığı veri ile imza tamamlanır.
    /// </summary>
    public class ProxyFinishSignForXadesRequestV4
    {
        /// <summary>
        /// e-İmza aracı tarafından imzalanmış veri (Base64).
        /// </summary>
        public string SignedData { get; set; }

        /// <summary>
        /// Mevcut e-imza işlemine ait ID değeridir. StepOne'dan döner.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Mevcut e-imza işlemine ait KeySecret değeridir. StepOne'dan döner.
        /// </summary>
        public string KeySecret { get; set; }

        /// <summary>
        /// StepOne'daki OperationId.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    /// <summary>
    /// V4 XAdES imzalı bir belgedeki imza bilgilerini sorgulamak için istek modeli.
    /// </summary>
    public class ProxyGetSignatureListXadesRequestV4
    {
        /// <summary>
        /// İmzaları okunacak dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Detached imzalarda: orijinal dosyanın OperationId'si (doğrulama için).
        /// Enveloped/Enveloping'de null/boş bırakılır.
        /// </summary>
        public Guid? OriginalFileOperationId { get; set; }
    }

    /// <summary>
    /// V4 XAdES imza listesi sorgulamasının sonucu.
    /// </summary>
    public class ProxyGetSignatureListXadesResultV4
    {
        /// <summary>
        /// Hata var ise detay bilgisi döner.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Dosyadaki imzaların detaylı bilgileri.
        /// </summary>
        public List<ProxyXadesSignatureInfoV4> Signatures { get; set; } = new();

        /// <summary>
        /// Dosyanın detached imza olup olmadığı.
        /// </summary>
        public bool IsDetached { get; set; }

        /// <summary>
        /// İmza modu: Enveloped, Enveloping, veya Detached.
        /// </summary>
        public string? SignatureMode { get; set; }
    }

    /// <summary>
    /// V4 XAdES imza zenginleştirme (upgrade) isteği.
    /// XAdES seviyeleri: T, XL, A. C ve X yoktur, BES→EPES yasak.
    /// </summary>
    public class ProxyUpgradeXadesRequestV4
    {
        /// <summary>
        /// Upgrade edilecek dosyanın OperationId'si.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Hedef seviye (mevcut seviyeden yüksek olmalı).
        /// </summary>
        public SignatureLevelForXadesV4 TargetLevel { get; set; }

        /// <summary>
        /// Upgrade edilecek imzanın EntityLabel'ı (örn: S0).
        /// Boş bırakılırsa ilk imza upgrade edilir.
        /// </summary>
        public string? SignaturePath { get; set; }

        /// <summary>
        /// Detached imzalarda: orijinal dosyanın OperationId'si.
        /// Enveloped/Enveloping'de null/boş bırakılır.
        /// </summary>
        public Guid? OriginalFileOperationId { get; set; }
    }

    /// <summary>
    /// V4 XAdES tek bir imzanın detaylı bilgisi.
    /// CAdES'e göre Scope yok, SignatureMode eklendi.
    /// PAdES'e göre ParentEntity ve LastArchivalTime var, SignatureMode eklendi.
    /// </summary>
    public class ProxyXadesSignatureInfoV4
    {
        /// <summary>
        /// İmzanın etiket bilgisi (örn: S0, S0:S0).
        /// </summary>
        public string EntityLabel { get; set; }

        /// <summary>
        /// İmza seviyesi (sayısal değer).
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// İmza seviyesinin metin karşılığı (örn: BES, T, XL, A).
        /// </summary>
        public string LevelString { get; set; }

        /// <summary>
        /// İmza sahibinin RDN (Relative Distinguished Name) bilgisi.
        /// </summary>
        public string SubjectRDN { get; set; }

        /// <summary>
        /// İmza sahibinin TC kimlik numarası (varsa).
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// İmzanın zaman damgalı olup olmadığı.
        /// </summary>
        public bool Timestamped { get; set; }

        /// <summary>
        /// İmza atılma zamanı (metin formatında).
        /// </summary>
        public string? ClaimedSigningTime { get; set; }

        /// <summary>
        /// İmza atılma zamanı (DateTime formatında).
        /// </summary>
        public DateTime? ClaimedSigningTimeAsTime { get; set; }

        /// <summary>
        /// Üst imzanın EntityLabel'ı (seri imzalarda).
        /// </summary>
        public string? ParentEntity { get; set; }

        /// <summary>
        /// İmza profil adı (örn: P2, P3, P4).
        /// </summary>
        public string? ProfileName { get; set; }

        /// <summary>
        /// İmza politika OID'si.
        /// </summary>
        public string? PolicyOID { get; set; }

        /// <summary>
        /// İmzada kullanılan hash algoritması.
        /// </summary>
        public string? HashAlgorithm { get; set; }

        /// <summary>
        /// İmzanın uzun vadeli doğrulama bilgisi içerip içermediği.
        /// </summary>
        public bool ContainsLongTermInfo { get; set; }

        /// <summary>
        /// Son arşiv zaman damgası zamanı (varsa).
        /// </summary>
        public string? LastArchivalTime { get; set; }

        /// <summary>
        /// Zaman damgası detay bilgisi.
        /// </summary>
        public ProxyTimestampInfoItemV4? Timestamp { get; set; }

        /// <summary>
        /// İmza modu: Enveloped, Enveloping, veya Detached.
        /// </summary>
        public string SignatureMode { get; set; }

        /// <summary>
        /// Mevcut seviyeden yapılabilecek upgrade seçenekleri (örn: ["T","XL","A"]).
        /// XAdES'te C ve X seviyeleri yoktur.
        /// </summary>
        public List<string> UpgradeOptions { get; set; } = new();

        /// <summary>
        /// Profil uyumlu upgrade seçenekleri. Profil yoksa null döner.
        /// </summary>
        public List<string>? ProfileRecommendedUpgrades { get; set; }

        /// <summary>
        /// Profil dışı upgrade seçenekleri. Profil yoksa null döner.
        /// </summary>
        public List<string>? ProfileIncompatibleUpgrades { get; set; }
    }

    #endregion

}
