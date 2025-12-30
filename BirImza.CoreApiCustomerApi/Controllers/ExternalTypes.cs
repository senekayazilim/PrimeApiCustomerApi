using BirImza.Types.Shared;
using System;
using System.Collections.Generic;

namespace  BirImza.Types
{
    public class SignStepOnePadesMobileCoreRequest : BaseRequest
    {
        /// <summary>
        /// İmzalanacak dosyadır
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
        /// </summary>
        public VerificationInfo VerificationInfo { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
        /// </summary>
        public QrCodeInfo QrCodeInfo { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// İmza atarken kullanıcıya gösterilecek mesaj
        /// </summary>
        public string UserPrompt { get; set; }
        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }
    }

    public class SignStepOnePadesMobileCoreRequestV2 : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

       
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// İmza atarken kullanıcıya gösterilecek mesaj
        /// </summary>
        public string UserPrompt { get; set; }
        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForPades? SignatureLevel { get; set; }


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

    public class SignStepOneCoreInternalForXadesRequest : BaseRequest
    {
        public string CerBytes { get; set; }

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

    public class SignStepOneXadesCoreRequest : BaseRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
        /// <summary>
        /// İmzalanacak dosyadır
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Enveloping:2, Enveloped:4. Değer verilmez ise 4, yani Enveloped imza atılır.
        /// </summary>
        public int? XmlSignatureType { get; set; }

        /// <summary>
        /// Enveloping imza durumunda, bu özellik, zarf içinde yer alan nesnenin MIME türü (MIME type) özniteliğini içerir. Default değeri application/pdf
        /// </summary>
        public string? EnvelopingObjectMimeType { get; set; }

        /// <summary>
        /// Enveloping imza durumunda, bu özellik, zarf içinde yer alan nesnenin Encoding (kodlama) özniteliğini içerir. Default değeri http://www.w3.org/2000/09/xmldsig#base64
        /// </summary>
        public string? EnvelopingObjectEncoding { get; set; }

    }

    public class SignStepOneCoreInternalForCadesRequest : BaseRequest
    {
        public string CerBytes { get; set; }
    }

    public class GetSignatureListCoreRequest : BaseRequest
    {
        
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

    }

    public class GetSignatureListCoreRequestV2 : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class SignStepOneCadesCoreRequest : BaseRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
        /// <summary>
        /// İmzalanacak dosyadır
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

    }

    public class SignStepOneCadesCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
       
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
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

    public class SignStepOneXadesCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }

        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
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
        public string? EnvelopingOrEnveloped { get; set; }

        /// <summary>
        /// application/pdf gibi mimetype değeri verilir. Boş değer verilirse application/pdf kullanılır.
        /// </summary>
        public string? EnvelopingObjectMimeType { get; set; }

        /// <summary>
        /// http://www.w3.org/2000/09/xmldsig#base64 gibi değer verilir. Boş değer verilirse http://www.w3.org/2000/09/xmldsig#base64 kullanılır.
        /// </summary>
        public string? EnvelopingObjectEncoding { get; set; }
    }

    public class SignStepOneCadesMobileCoreRequest : BaseRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
        /// <summary>
        /// İmzalanacak dosyadır
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// İmza atarken kullanıcıya gösterilecek mesaj
        /// </summary>
        public string UserPrompt { get; set; }
        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }

    }

    public class SignStepOneCadesMobileCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        

        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// İmza atarken kullanıcıya gösterilecek mesaj
        /// </summary>
        public string UserPrompt { get; set; }
        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }

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
    }

    public class SignStepOneXadesMobileCoreRequestV2 : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        

        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// İmza atarken kullanıcıya gösterilecek mesaj
        /// </summary>
        public string UserPrompt { get; set; }
        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForXades? SignatureLevel { get; set; }

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
        /// Enveloping veya Enveloped imza atılıp atılacağını belirler, boş geçilirse Enveloped imza atılır.
        /// Olası değerler
        /// ENVELOPING
        /// ENVELOPED
        /// </summary>
        public string EnvelopingOrEnveloped { get; set; }
    }

    public class SignStepOneXadesMobileCoreRequest : BaseRequest
    {
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
        /// <summary>
        /// İmzalanacak dosyadır
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// İmza atarken kullanıcıya gösterilecek mesaj
        /// </summary>
        public string UserPrompt { get; set; }
        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

    }

    public class SignStepOneCoreInternalForPadesMobileRequest : BaseRequest
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPrompt { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public string OperatorName { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }
    }

    public class SignStepOneCoreInternalForPadesMobileRequestV2 : BaseRequest
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPrompt { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public string OperatorName { get; set; }
        ///// <summary>
        ///// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        ///// </summary>
        //public int SignatureIndex { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForPades? SignatureLevel { get; set; }

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

    public class SignStepOneCoreInternalForCadesMobileRequest : BaseRequest
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPrompt { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public string OperatorName { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }

        /// <summary>
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }
    }

    public class SignStepOneCoreInternalForCadesMobileRequestV2 : BaseRequest
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPrompt { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public string OperatorName { get; set; }

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
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }

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

    public class SignStepOneCoreInternalForXadesMobileRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPrompt { get; set; }
        
        public string OperatorName { get; set; }

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
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForXades? SignatureLevel { get; set; }

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
        
    }

    public class SignStepOneCoreInternalForXadesMobileRequest : BaseRequest
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPrompt { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public string OperatorName { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }

        /// <summary>
        /// Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
        /// </summary>
        public string? CitizenshipNo { get; set; }
    }
    public class SignStepOnePadesCoreRequest : BaseRequest
    {

        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
        /// <summary>
        /// İmzalanacak dosyadır
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosya üzerinde kaçıncı imza olduğu bilgisidir. Dosya üzerinde hiç imza yok ise 0 değeri atanır.
        /// </summary>
        public int SignatureIndex { get; set; }
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
        /// </summary>
        public VerificationInfo VerificationInfo { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
        /// </summary>
        public QrCodeInfo QrCodeInfo { get; set; }

        /// <summary>
        /// Sayfa üzerine eklenecek imza görseli bilgisidir
        /// </summary>
        public SignatureWidgetInfo SignatureWidgetInfo { get; set; }
    }

    public class SignStepOnePadesCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Son kullanıcı bilgisayarında bulunana e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
        /// </summary>
        public string CerBytes { get; set; }
       
        /// <summary>
        /// Son kullanıcının geolocation bilgisidir. API bu alanı şimdilik kullanmamaktadır. Bu nedenle null olarak atanabilir.
        /// </summary>
        public SignStepOneRequestCoordinates Coordinates { get; set; }
        
        
        
        /// <summary>
        /// Sayfa üzerine eklenecek imza görseli bilgisidir
        /// </summary>
        public SignatureWidgetInfo SignatureWidgetInfo { get; set; }

    }



    public class AddLayersCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
        /// </summary>
        public VerificationInfo VerificationInfo { get; set; }

        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
        /// </summary>
        public QrCodeInfo QrCodeInfo { get; set; }
    }
    public class AddLayersCoreRequest : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Üzerine layer eklenecek dosya verisidir
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Üzerine layer eklenecek dosya adıdır
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
        /// </summary>
        public VerificationInfo VerificationInfo { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
        /// </summary>
        public QrCodeInfo QrCodeInfo { get; set; }
    }

    public class AddLayersToExistingFileCoreRequest : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
        /// </summary>
        public VerificationInfo VerificationInfo { get; set; }
        /// <summary>
        /// İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
        /// </summary>
        public QrCodeInfo QrCodeInfo { get; set; }
    }

    public class DownloadSignedFileCoreRequest : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class DownloadSignedFileCoreRequestV2 : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

    }

    public class DownloadSignedFileCoreResult
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Dosya verisidir
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Dosyanın adıdır
        /// </summary>
        public string FileName { get; set; }
    }

    public class SignStepOneXadesCoreResult
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


        public Guid OperationId { get; set; }
    }

    public class ConvertToPdfCoreResult
    {
        /// <summary>
        /// Dönüştürülmüş dosya verisidir
        /// </summary>
        public byte[] FileData { get; set; }
    }

    public class ConvertToPdfCoreResultV2
    {
        public Guid OperationId { get; set; }
    }

    public class AddLayersCoreResult
    {
        /// <summary>
        /// Üzerine layer eklenmiş dosya verisidir
        /// </summary>
        public byte[] FileData { get; set; }
    }

    public class AddLayersCoreResultV2
    {
        public Guid OperationId { get; set; }
    }

    public class AddLayersToExistingFileCoreResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }
    }

    public class ConvertToPdfCoreRequest : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Dönüştürülecek dosya verisidir
        /// </summary>
        public byte[] FileData { get; set; }
        /// <summary>
        /// Döüştürülecek dosya adıdır
        /// </summary>
        public string FileName { get; set; }
    }


    public class ConvertToPdfCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Orijinal, yani dönüştürülmek istenen dosyanın uzantısıdır.
        /// Olası değerler 
        /// .docx .doc .xlsx .xls .pptx .ppt .jpeg .jpg .png .gif .tiff .tifs
        /// </summary>
        public string FileExtension { get; set; }
    }




    public class SignStepThreeCadesCoreRequest : BaseRequest
    {
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
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }
    }

    public class SignStepThreeCadesCoreRequestV2 : BaseRequest
    {
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
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForCades? SignatureLevel { get; set; }

        
    }

    public class SignStepThreeXadesCoreRequestV2 : BaseRequest
    {
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
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForXades? SignatureLevel { get; set; }


    }



    public class SignStepThreePadesCoreRequest : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
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
        


    }

    public class SignStepThreePadesCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
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
        /// Null geçilirse BES türünde atılır.
        /// </summary>
        public SignatureLevelForPades? SignatureLevel { get; set; }


    }

    public class SignStepThreeXadesCoreRequest : BaseRequest
    {
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

    public class UpgradePadesCoreRequest : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class UpgradeCadesCoreRequestV2 : BaseRequest
    {


        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Ne tür imzaya upgrade edileceği bilgisi
        /// </summary>
        public SignatureLevelForCades SignatureLevel { get; set; }

        /// <summary>
        /// Hangi imzacının upgrade edileceği bilgisi, null geçilirse dosyadaki her imza upgrade edilir
        /// </summary>
        public string? SignaturePath { get; set; }
    }

    public class UpgradePadesCoreRequestV2 : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Ne tür imzaya upgrade edileceği bilgisi
        /// </summary>
        public SignatureLevelForPades SignatureLevel { get; set; }

        /// <summary>
        /// Hangi imzacının upgrade edileceği bilgisi, null geçilirse dosyadaki her imza upgrade edilir
        /// </summary>
        public string? SignaturePath { get; set; }
    }

    public class VerifyPadesV2Request : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }

       
    }

    public class VerifyPadesV2Result : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        public bool AllSignaturesValid { get; set; }

        public List<VerifyPadesV2ResultItem> Signatures { get; set; }
    }

    public class VerifyPadesV2ResultItem : BaseRequest
    {

        public string ValidatedSigningTime { get; set; }
        public string ChainValidationResult { get; set; }
        public string ClaimedSigningTime { get; set; }
        public bool ContainsLongTermInfo { get; set; }
        public string HashAlgorithm { get; set; }
        public string IssuerRDN { get; set; }
        public string Level { get; set; }
        public string PolicyHash { get; set; }
        public string PolicyHashAlgorithm { get; set; }
        public string PolicyID { get; set; }
        public string PolicyURI { get; set; }
        public string Reason { get; set; }
        public string SignatureType { get; set; }
        public string SubjectRDN { get; set; }
        public bool Timestamped { get; set; }
    }

    public class UpgradeXadesCoreRequestV2 : BaseRequest
    {


        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Ne tür imzaya upgrade edileceği bilgisi
        /// </summary>
        public SignatureLevelForXades SignatureLevel { get; set; }

        /// <summary>
        /// Hangi imzacının upgrade edileceği bilgisi, null geçilirse dosyadaki her imza upgrade edilir
        /// </summary>
        public string? SignaturePath { get; set; }
    }

    public class UpgradeCadesCoreRequest : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class UpgradeXadesCoreRequest : BaseRequest
    {

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class SignStepThreePadesCoreResult
    {
        public bool IsSuccess { get; set; }
        public Guid OperationId { get; set; }
    }

    public class SignStepThreeXadesCoreResult
    {
        public bool IsSuccess { get; set; }
        public Guid OperationId { get; set; }
    }

    public class UpgradePadesCoreResult
    {
        public bool IsSuccess { get; set; }
        public Guid OperationId { get; set; }
    }

    public class UpgradeCadesCoreResult
    {
        public bool IsSuccess { get; set; }
        public Guid OperationId { get; set; }
    }

    public class UpgradeXadesCoreResult
    {
        public bool IsSuccess { get; set; }
        public Guid OperationId { get; set; }
    }

    public class GetFingerPrintCoreRequest : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class GetFingerPrintCoreRequestV2 : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class GetFingerPrintCoreResult
    {
        public string FingerPrint { get; set; }
    }

    public class SignStepOneCadesCoreResult
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
        public Guid OperationId { get; set; }
    }

    public class GetSignatureListCoreResult
    {

        public IEnumerable<GetSignatureListCoreResultItem> Signatures { get; set; }
        public Guid OperationId { get; set; }
    }

    public class GetSignatureListCoreResultItem
    {
        public string EntityLabel { get; set; }
        public int Level { get; set; }
        public string LevelString { get; set; }
        public string SubjectRDN { get; set; }
        public bool Timestamped { get; set; }
        public string ClaimedSigningTime { get; set; }
        public string? CitizenshipNo { get; set; }
        public string? XadesSignatureType { get; set; }
    }



    public class SignStepOneCoreInternalForPadesResult
    {
        public string State { get; set; }
        public string KeyID { get; set; }
        public string KeySecret { get; set; }
    }

    public class JavaPadesValidationResult
    {
        public List<SignatureValidationItem> signatureValidations { get; set; }

        /// <summary>
        /// ALL_VALID, CONTAINS_INVALID, CONTAINS_INCOMPLETE 
        /// </summary>
        public string summary { get; set; }
    }

    public class SignatureValidationItem
    {
        public bool isExpanded { get; set; }
        public string signerFullName { get; set; }
        public string serialNumber { get; set; }
        public string reason { get; set; }
        public string signatureType { get; set; }
        public string signatureFormat { get; set; }
        public string signatureAlg { get; set; }
        public DateTime? signingTime { get; set; }
        public DateTime? signingTimeDeclared { get; set; }
        public string policyDigestAlgorithm { get; set; }
        public string policyId { get; set; }
        public string policyUri { get; set; }
        public string policyUserNotice { get; set; }
        public string policyTurkishESigProfile { get; set; }

        public bool hasTimestamp { get; set; }
        public TimestampValidationItem timestamp { get; set; }

        public string validationResult { get; set; }
        public string validationResultType { get; set; }
        public string validationCertificateStatusInfoCheckResults { get; set; }
        public string validationCertificateStatusInfoDetailedMessage { get; set; }
        public string validationCertificateStatusInfoDetailedValidationReport { get; set; }
        public string validationCertificateStatusInfoCheckResultsToString { get; set; }
        public string validationCertificateStatusInfoValidationHistory { get; set; }
        public string validationCertificateStatusInfotCertificateStatus { get; set; }

        public List<SignatureValidationItem> counterSignatureValidations { get; set; }
        public SignatureValidationItem()
        {
        }
    }

    public class TimestampValidationItem
    {
        public string timestampType { get; set; }
        public DateTime dateOfTimestmap { get; set; }

        public TimestampValidationItem()
        {

        }
    }

    /// <summary>
    /// Chunked upload iptal isteği.
    /// </summary>
    public class AbortChunkedUploadRequest : BaseRequest
    {
        /// <summary>
        /// InitializeChunkedUpload çağrısından dönen UploadSessionId.
        /// </summary>
        public Guid UploadSessionId { get; set; }
    }

    /// <summary>
    /// Chunked upload iptal yanıtı.
    /// </summary>
    public class AbortChunkedUploadResult
    {
        /// <summary>
        /// Oturum iptal edildiyse true döner.
        /// </summary>
        public bool Aborted { get; set; }
    }

    /// <summary>
    /// Chunked upload tamamlama isteği. Sunucu tüm parçaları birleştirir ve orijinal dosyayı hazırlar.
    /// </summary>
    public class CompleteChunkedUploadRequest : BaseRequest
    {
        /// <summary>
        /// InitializeChunkedUpload çağrısından dönen UploadSessionId.
        /// </summary>
        public Guid UploadSessionId { get; set; }
    }

    /// <summary>
    /// Chunked upload tamamlama yanıtı.
    /// </summary>
    public class CompleteChunkedUploadResult
    {
        /// <summary>
        /// Birleştirme ve finalize işlemi başarılı ise true.
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    /// <summary>
    /// Chunked upload başlatma isteği. Büyük dosyaları Cloudflare limiti altında parçalara bölerek yüklemek için kullanılır.
    /// </summary>
    public class InitializeChunkedUploadRequest : BaseRequest
    {
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Her bir parçanın bayt cinsinden boyutu. 100MB altında bir değer önerilir (örn. 8–16MB).
        /// </summary>
        public int ChunkSize { get; set; }
        /// <summary>
        /// Dosyanın toplam bayt cinsinden boyutu.
        /// </summary>
        public long TotalSize { get; set; }
        /// <summary>
        /// Toplam parça sayısı. TotalSize / ChunkSize üst tamsayıya yuvarlanır.
        /// </summary>
        public int TotalChunks { get; set; }

    }

    /// <summary>
    /// Chunked upload başlatma yanıtı.
    /// </summary>
    public class InitializeChunkedUploadResult
    {
        /// <summary>
        /// Yükleme oturum kimliğidir. Parça yükleme, durum ve tamamlama çağrılarında kullanılır.
        /// </summary>
        public Guid UploadSessionId { get; set; }
        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        /// <summary>
        /// Sunucu tarafından kabul edilen parça boyutu.
        /// </summary>
        public int ChunkSize { get; set; }
        /// <summary>
        /// Toplam parça sayısı.
        /// </summary>
        public int TotalChunks { get; set; }
        
    }

    

    public class SignStepOneCoreInternalForCadesMobileResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Sunucu tarafından oluşturulmuş OperationId'dir.
        /// </summary>
        public Guid OperationId { get; set; }

        
    }

    public class SignStepOneCoreInternalForPadesMobileResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Sunucu tarafından oluşturulmuş OperationId'dir.
        /// </summary>
        public Guid OperationId { get; set; }

        
    }

    public class SignStepOneCoreInternalForXadesMobileResult
    {
        /// <summary>
        /// İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Sunucu tarafından oluşturulmuş OperationId'dir.
        /// </summary>
        public Guid OperationId { get; set; }

        
    }

    public class SignStepOnePadesCoreResult
    {
        public string State { get; set; }
        public string KeyID { get; set; }
        public string KeySecret { get; set; }
        public Guid OperationId { get; set; }
    }

    public class SignStepOneUploadFileResult
    {
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
    }

    public class UploadFileV2Result
    {
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
        /// </summary>
        public Guid OperationId { get; set; }
        
    }

    public class VerifySignaturesCoreResult
    {
        public bool CaptchaError { get; set; }
        public bool AllSignaturesValid { get; set; }
        public List<VerifyDocumentResultSignature> Signatures { get; set; }
        public List<VerifyDocumentResultTimestamp> Timestamps { get; set; }
        public string FileName { get; set; }
        public string SignatureType { get; set; }
    }

    public class SignStepThreeCadesCoreResult
    {
        public bool IsSuccess { get; set; }

        public Guid OperationId { get; set; }
    }

    /// <summary>
    /// Bir parça yükleme çağrısının sonucu.
    /// </summary>
    public class UploadChunkResult
    {
        /// <summary>
        /// Parça kabul edildiyse true döner. Aynı parça tekrar yüklense bile idempotent olarak true dönebilir.
        /// </summary>
        public bool Accepted { get; set; }
    }

    public class SignStepOneRequestCoordinates
    {
        /// <summary>
        /// The accuracy of position
        /// </summary>
        public double? Accuracy { get; set; }
        /// <summary>
        /// The altitude in meters above the mean sea level
        /// </summary>
        public double? Altitude { get; set; }
        /// <summary>
        /// The altitude accuracy of position
        /// </summary>
        public double? AltitudeAccuracy { get; set; }
        /// <summary>
        /// The heading as degrees clockwise from North
        /// </summary>
        public double? Heading { get; set; }
        /// <summary>
        /// The latitude as a decimal number
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// The longitude as a decimal number
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// The speed in meters per second
        /// </summary>
        public double? Speed { get; set; }
    }

    public class VerificationInfo
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

    public class QrCodeInfo
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

    public class SignatureWidgetInfo
    {
        /// <summary>
        /// İmzanın pixel olarak genişliğidir
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// İmzanın pixel olarak yüksekliğidir
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// İmzanın sayfanın solundan olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için left değer 0.1 verilirse, imza sayfanın solundan uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Left { get; set; }
        /// <summary>
        /// İmzanın sayfanın sağından olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için right değer 0.1 verilirse, imza sayfanın sağından uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Right { get; set; }
        /// <summary>
        /// İmzanın sayfanın üstünden olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için top değer 0.1 verilirse, imza sayfanın üstünden uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Top { get; set; }
        /// <summary>
        /// İmzanın sayfanın altından olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için bottom değer 0.1 verilirse, imza sayfanın altından uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
        /// </summary>
        public float? Bottom { get; set; }
        // <summary>
        /// İmzanın lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir. Örnekler: "left top", "right top"
        /// </summary>
        public string TransformOrigin { get; set; }
        /// <summary>
        /// İmza görselinde arka plan görseli olarak kullanılacak imajın datasıdır. İmaj jpg olmalıdır
        /// </summary>
        public byte[] ImageBytes { get; set; }
        /// <summary>
        /// İmza görselinin hangi sayfalara yerleştirileceği bilgisidir, 0 dan başlar.
        /// </summary>
        public int[] PagesToPlaceOn { get; set; }
        /// <summary>
        /// İmza görseli içerisinde yazılacak ifadelerdir.
        /// </summary>
        public List<LineInfo> Lines { get; set; }
    }

    public class VerifyDocumentResultSignature
    {
        public string ChainValidationResult { get; set; }
        public DateTime ClaimedSigningTime { get; set; }
        public string HashAlgorithm { get; set; }
        public string Profile { get; set; }
        public bool Timestamped { get; set; }
        public string Reason { get; set; }
        public string Level { get; set; }
        public string CitizenshipNo { get; set; }
        public string FullName { get; set; }

        public bool IsExpanded { get; set; }
        public int Index { get; set; }

        public string IssuerRDN { get; set; }

        public byte[] SerialNumber { get; set; }
        public string SerialNumberString
        {
            get
            {
                if (SerialNumber == null || SerialNumber.Length == 0)
                {
                    return null;
                }
                else
                {
                    return BitConverter.ToString(SerialNumber);
                }
            }
        }

        public byte[] SubjectKeyID { get; set; }

        public string SubjectKeyIDString
        {
            get
            {
                if (SubjectKeyID == null || SubjectKeyID.Length == 0)
                {
                    return null;
                }
                else
                {
                    return BitConverter.ToString(SubjectKeyID);
                }
            }
        }

        public string PolicyDigestAlgorithm { get; set; }
        public string PolicyId { get; set; }
        public string PolicyTurkishESigProfile { get; set; }
        public string PolicyUri { get; set; }
        public string PolicyUserNotice { get; set; }
        public string SignatureFormat { get; set; }
        public string ValidationResultType { get; set; }
        public string ValidationCertificateStatusInfoCheckResults { get; set; }
        public string SignatureType { get; set; }
        public string ValidationCertificateStatusInfoDetailedMessage { get; set; }
        public string ValidationCertificateStatusInfoDetailedValidationReport { get; set; }
        public string ValidationCertificateStatusInfoCheckResultsToString { get; set; }
        public string ValidationCertificateStatusInfoValidationHistory { get; set; }
        public string ValidationCertificateStatusInfotCertificateStatus { get; set; }
    }

    public class VerifyDocumentResultTimestamp
    {
        public DateTime Time { get; set; }
        public string TSAName { get; set; }
        public int TimestampType { get; set; }
        public int Index { get; set; }

        public string IssuerRDN { get; set; }
        public byte[] SerialNumber { get; set; }

        public string SerialNumberString
        {
            get
            {
                if (SerialNumber == null || SerialNumber.Length == 0)
                {
                    return null;
                }
                else
                {
                    return BitConverter.ToString(SerialNumber);
                }
            }
        }

        public byte[] SubjectKeyID { get; set; }

        public string SubjectKeyIDString
        {
            get
            {
                if (SubjectKeyID == null || SubjectKeyID.Length == 0)
                {
                    return null;
                }
                else
                {
                    return BitConverter.ToString(SubjectKeyID);
                }
            }
        }
    }

    public class LineInfo
    {
        /// <summary>
        /// Satır içerisinde yazacak ifadedir
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Satırın sol marjinidir.
        /// </summary>
        public int LeftMargin { get; set; }
        /// <summary>
        /// Satırın tepe marjinidir.
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
        /// Satırın hangi font tipi ile yazılacağını belirler. Regular, Bold, Italic, Underline, Strikeout
        /// </summary>
        public string FontStyle { get; set; }
        /// <summary>
        /// Satırın hangi renkle yazılacağını belirleri. #FF00FF gibi kullanınız.
        /// </summary>
        public string ColorHtml { get; set; }

    }

    public class BaseRequest
    {
        public string RequestId { get; set; }
        public string DisplayLanguage { get; set; }
    }

    public class ApiResult<T>
    {
        /// <summary>
        /// API metodu sonucunda dönen değerdir
        /// </summary>
        public T Result { get; set; }
        /// <summary>
        /// Varsa hataya ilişkin mesaj ve açıklayıcı bilgi dönülür
        /// </summary>
        public string Error { get; set; }
    }

    /// <summary>
    /// Chunk status sorgulama yanıtı.
    /// </summary>
    public class GetUploadStatusResult
    {
        /// <summary>
        /// Toplam parça sayısı.
        /// </summary>
        public int TotalChunks { get; set; }
        /// <summary>
        /// Sunucuya ulaşmış parça indeksleri listesi (0 tabanlı).
        /// </summary>
        public List<int> ReceivedChunkIndices { get; set; }
    }

    /// <summary>
    /// Chunk status sorgulama isteği.
    /// </summary>
    public class GetUploadStatusRequest : BaseRequest
    {
        /// <summary>
        /// InitializeChunkedUpload çağrısından dönen UploadSessionId.
        /// </summary>
        public Guid UploadSessionId { get; set; }
    }

}

