





export interface ProxyCreateStateOnOnaylarimApiRequest {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
 * </summary>
 */
  signatureType: string;
/**
 * <summary>
 * Enveloping:2, Enveloped:4. Değer verilmez ise 4, yani Enveloped imza atılır.
 * </summary>
 */
  xmlSignatureType: number | null;
/**
 * <summary>
 * Enveloping imza durumunda, bu özellik, zarf içinde yer alan nesnenin Encoding (kodlama) özniteliğini içerir. Default değeri http://www.w3.org/2000/09/xmldsig#base64
 * </summary>
 */
  envelopingObjectEncoding: string | null;
/**
 * <summary>
 * Enveloping imza durumunda, bu özellik, zarf içinde yer alan nesnenin MIME türü (MIME type) özniteliğini içerir. Default değeri application/pdf
 * </summary>
 */
  envelopingObjectMimeType: string | null;
}



export interface ProxyCreateStateOnOnaylarimApiForPadesRequestV2 {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
}



export interface ProxyCreateStateOnOnaylarimApiForCadesRequestV2 {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse Parallel imza atılır.
 * Olası değerler
 * SERIAL
 * PARALLEL
 * </summary>
 */
  serialOrParallel: string;
/**
 * <summary>
 * Seri imza atılacaksa, dosya üzerinde hangi imzanın üzerine imza atılacağı bilgisidir. Dosya üzerinde hiç imza yoksa boş geçilir.
 * Dosya üzerine tek imza var ise ve o imzanın üzerine imza atılacaksa S0 gönderilir.
 * Dosya üzerinde iki tane imza var ise ve ikinci imza üzerine imza atılacaksa S0:S0 gönderilir.
 * Parallel imzada bu parametre yok sayılır.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
 * </summary>
 */
  citizenshipNo: string | null;
/**
 * <summary>
 * İmza profilleri P1, P2, P3, P4. Şuan sadece P4 desteklenmektedir. Profil istenmiyorsa bu alan null geçilir.
 * Olası değerler
 * P1
 * P2
 * P3
 * P4
 * </summary>
 */
  signatureTurkishProfile: string | null;
}



export interface ProxyCreateStateOnOnaylarimApiForXadesRequestV2 {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse Parallel imza atılır.
 * Olası değerler
 * SERIAL
 * PARALLEL
 * </summary>
 */
  serialOrParallel: string;
/**
 * <summary>
 * Seri imza atılacaksa, dosya üzerinde hangi imzanın üzerine imza atılacağı bilgisidir. Dosya üzerinde hiç imza yoksa boş geçilir.
 * Dosya üzerine tek imza var ise ve o imzanın üzerine imza atılacaksa S0 gönderilir.
 * Dosya üzerinde iki tane imza var ise ve ikinci imza üzerine imza atılacaksa S0:S0 gönderilir.
 * Parallel imzada bu parametre yok sayılır.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
 * </summary>
 */
  citizenshipNo: string | null;
/**
 * <summary>
 * İmza profilleri P1, P2, P3, P4. Şuan sadece P4 desteklenmektedir. Profil istenmiyorsa bu alan null geçilir.
 * Olası değerler
 * P1
 * P2
 * P3
 * P4
 * </summary>
 */
  signatureTurkishProfile: string | null;
/**
 * <summary>
 * Enveloping veya Enveloped imza atılıp atılacağını belirler, boş geçilirse Enveloped imza atılır.
 * Olası değerler
 * ENVELOPING
 * ENVELOPED
 * </summary>
 */
  envelopingOrEnveloped: string;
/**
 * <summary>
 * application/pdf gibi mimetype değeri verilir. Boş değer verilirse application/pdf kullanılır.
 * </summary>
 */
  envelopingObjectMimeType: string | null;
/**
 * <summary>
 * http://www.w3.org/2000/09/xmldsig#base64 gibi değer verilir. Boş değer verilirse http://www.w3.org/2000/09/xmldsig#base64 kullanılır.
 * </summary>
 */
  envelopingObjectEncoding: string | null;
}



export interface ProxyCreateStateOnOnaylarimApiResult {
/**
 * <summary>
 * e-İmza aracına iletilecek, e-imza state'idir.
 * </summary>
 */
  state: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keyID: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
  error: string;
}





export interface ProxyGetFingerPrintRequest {
  operationId: string;
}



export interface ProxyGetFingerPrintResult {
  fingerPrint: string;
}



export interface ProxyFinishSignRequest {
/**
 * <summary>
 * İmza işlemi sonrası imzanın LTV'ye upgrade edilip edilmeyeceğini belirler. Belgede N imza olacaksa, 1, 2, 3 ... , N-1 inci imzalar için True, sadece son imza için False gönderilmelidir.
 * </summary>
 */
  dontUpgradeToLtv: boolean;
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
 * </summary>
 */
  signatureType: string;
}



export interface ProxyFinishSignForPadesRequestV2 {
/**
 * <summary>
 * Null geçilirse BES türünde atılır.
 * </summary>
 */
  signatureLevel: SignatureLevelForPades | null;
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
}



export interface ProxyFinishSignForCadesRequestV2 {
/**
 * <summary>
 * Null geçilirse BES türünde atılır.
 * </summary>
 */
  signatureLevel: SignatureLevelForCades | null;
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
}



export interface ProxyFinishSignForXadesRequestV2 {
/**
 * <summary>
 * Null geçilirse BES türünde atılır.
 * </summary>
 */
  signatureLevel: SignatureLevelForXades | null;
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. e-İmza aracına iletilir.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
}



export interface ProxyFinishSignResult {
/**
 * <summary>
 * İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
 * </summary>
 */
  isSuccess: boolean;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: any;
}



export interface ProxyMobilSignResult {
/**
 * <summary>
 * İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
 * </summary>
 */
  isSuccess: boolean;
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
}



export interface ProxyMobilSignResultV2 {
/**
 * <summary>
 * İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
 * </summary>
 */
  isSuccess: boolean;
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
  operationId: string;
}



export interface ProxyUploadFileResult {
/**
 * <summary>
 * İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
 * </summary>
 */
  isSuccess: boolean;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
}



export interface ProxyUploadFileResultV2 {
/**
 * <summary>
 * İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
 * </summary>
 */
  isSuccess: boolean;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
}







export interface ProxyMobileSignRequest {
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
 * </summary>
 */
  signatureType: string;
/**
 * <summary>
 * İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
 * </summary>
 */
  phoneNumber: string;
/**
 * <summary>
 * İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
 * </summary>
 */
  operator: string;
/**
 * <summary>
 * Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
 * </summary>
 */
  citizenshipNo: string | null;
}



export interface ProxyMobileSignRequestV2 {
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * atılacak e-imza türüdür, değerler pades, xades ve cades olabilir
 * </summary>
 */
  signatureType: string;
/**
 * <summary>
 * İmza atarken kullanılacak mobil imzaya ait telefon numarasıdır. Örnek: 5446786666
 * </summary>
 */
  phoneNumber: string;
/**
 * <summary>
 * İmza atarken kullanılacak mobil imzaya ait telefon numarasının bağlı olduğu operatördür. Örnek: TURKCELL, VODAFONE, AVEA
 * </summary>
 */
  operator: string;
/**
 * <summary>
 * Mobil imza sahibi kişinin TC'si verilmesi durumunda, mobil imza sertifikası içindeki TC ile kontrol yapılır
 * </summary>
 */
  citizenshipNo: string | null;
/**
 * <summary>
 * Sadece CADES imzalar için. Null geçilirse BES türünde atılır.
 * </summary>
 */
  signatureLevelForCades: SignatureLevelForCades | null;
/**
 * <summary>
 * Sadece PADES imzalar için. Null geçilirse BES türünde atılır.
 * </summary>
 */
  signatureLevelForPades: SignatureLevelForPades | null;
/**
 * <summary>
 * Sadece XADES imzalar için. Null geçilirse BES türünde atılır.
 * </summary>
 */
  signatureLevelForXades: SignatureLevelForXades | null;
/**
 * <summary>
 * Seri imza atılacaksa, dosya üzerinde hangi imzanın üzerine imza atılacağı bilgisidir. Dosya üzerinde hiç imza yoksa boş geçilir.
 * Dosya üzerine tek imza var ise ve o imzanın üzerine imza atılacaksa S0 gönderilir.
 * Dosya üzerinde iki tane imza var ise ve ikinci imza üzerine imza atılacaksa S0:S0 gönderilir.
 * Parallel imzada bu parametre yok sayılır.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * İmza profilleri P1, P2, P3, P4. Şuan sadece P4 desteklenmektedir. Profil istenmiyorsa bu alan null geçilir.
 * Olası değerler
 * P1
 * P2
 * P3
 * P4
 * </summary>
 */
  signatureTurkishProfile: string | null;
/**
 * <summary>
 * Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse Parallel imza atılır.
 * Olası değerler
 * SERIAL
 * PARALLEL
 * </summary>
 */
  serialOrParallel: string | null;
/**
 * <summary>
 * PADES imzada, PDF üzerine QR kod gibi alanlar ekleniyor.
 * Örnek kullanım sırasında, daha önce imza atılmış bir PDF imzalanmak istendiğinde bu QR Kod gibi alanların eklenmesinin engellenmesi gerekir.
 * Bu nedenle eğer IsFirstSigner false ise QR kod alanı eklenmeyecek şekilde süreç çalıştırılır
 * </summary>
 */
  isFirstSigner: boolean;
/**
 * <summary>
 * Enveloping veya Enveloped imza atılıp atılacağını belirler, boş geçilirse Enveloped imza atılır.
 * Olası değerler
 * ENVELOPING
 * ENVELOPED
 * </summary>
 */
  envelopingOrEnveloped: string;
}



export interface ProxyGetSignatureListResult {
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
  signatures: Array<ProxyGetSignatureListResultItem>;
}



export interface ProxyGetSignatureListResultV3 {
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
  signatures: Array<ProxyGetSignatureListResultItemV3>;
}



export interface ProxyGetSignatureListResultItem {
  entityLabel: string;
  level: number;
  levelString: string;
  subjectRDN: string;
  timestamped: boolean;
  claimedSigningTime: string;
  citizenshipNo: string | null;
  xadesSignatureType: string | null;
}



export interface ProxyGetSignatureListResultItemV3 {
  entityLabel: string;
  level: number;
  levelString: string;
  subjectRDN: string;
  timestamped: boolean;
  claimedSigningTime: string;
  citizenshipNo: string | null;
  xadesSignatureType: string | null;
  timestamp: ProxyTimestampInfoItemV3 | null;
  parentEntity: string;
  claimedSigningTimeAsTime: string | null;
}



export interface ProxyTimestampInfoItemV3 {
  entityLabel: string;
  time: string;
  timeAsTime: string | null;
}



export interface ProxyAddVerificationInfoCoreRequest {
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Bu değer aynı e-imza işlemi ile ilgili olarak daha sonraki metodlarda kullanılır.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * İmzalanacak doküman üzerinde eklenecek cümleyle ilgili bilgileri içerir
 * </summary>
 */
  verificationInfo: ProxyVerificationInfoInner;
/**
 * <summary>
 * İmzalanacak doküman üzerinde eklenecek QRCode ilgili bilgileri içerir
 * </summary>
 */
  qrCodeInfo: ProxyQrCodeInfoInner;
}



export interface ProxyQrCodeInfoInner {
/**
 * <summary>
 * QR kod içinde yazacak URL bilgisidir
 * </summary>
 */
  text: string;
/**
 * <summary>
 * Karekodun genişliğinin sayfa genişliğine oranıdır. Sayfa genişliği 1000 olan bir sayfa için width değer 0.8 verilirse, karekod genişliği 800 olur. Karekodun genişliği ve yüksekliği eşittir
 * </summary>
 */
  width: number;
/**
 * <summary>
 * Karekodun sayfanın solundan olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için left değer 0.1 verilirse, karekod sayfanın solundan uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  left: number | null;
/**
 * <summary>
 * Karekodun sayfanın sağından olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için right değer 0.1 verilirse, karekod sayfanın sağından uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  right: number | null;
/**
 * <summary>
 * Karekodun sayfanın üstünden olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için top değer 0.1 verilirse, karekod sayfanın üstünden uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  top: number | null;
/**
 * <summary>
 * Karekodun sayfanın altından olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için bottom değer 0.1 verilirse, karekod sayfanın altından uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  bottom: number | null;
/**
 * Karekodun lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir. Örnekler: "left top", "right top"
 * </summary>
 */
  transformOrigin: string;
}



export interface ProxyVerificationInfoInner {
/**
 * <summary>
 * Doğrulama cümlesidir. Yeni satır için \r\n değeri girilebilir. Örnek: Satır 1\r\nSatır2
 * </summary>
 */
  text: string;
/**
 * <summary>
 * İmzalama cümlesi kutusunun, sayfa genişliğine oranıdır. Sayfa genişliği 1000 olan bir sayfa için width değer 0.8 verilirse, doğrulama cümlesi genişliği 800 olur.
 * </summary>
 */
  width: number;
/**
 * <summary>
 * İmzalama cümlesi kutusunun, sayfa yüksekliğine oranıdır. Sayfa yüksekliği 1000 olan bir sayfa için height değer 0.1 verilirse, doğrulama cümlesi yüksekliği 100 olur.
 * </summary>
 */
  height: number;
/**
 * <summary>
 * İmzalama cümlesi kutusunun sayfanın solundan olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için left değer 0.1 verilirse, doğrulama cümlesinin sayfanın solundan uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  left: number | null;
/**
 * <summary>
 * İmzalama cümlesi kutusunun sayfanın sağından olan uzaklığıdır. Sayfa genişliği 1000 olan bir sayfa için right değer 0.1 verilirse, doğrulama cümlesinin sayfanın sağından uzaklığı 100 olur. Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  right: number | null;
/**
 * <summary>
 * İmzalama cümlesi kutusunun sayfanın üstünden olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için top değer 0.1 verilirse, doğrulama cümlesinin sayfanın üstünden uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  top: number | null;
/**
 * <summary>
 * İmzalama cümlesi kutusunun sayfanın altından olan uzaklığıdır. Sayfa yüksekliği 1000 olan bir sayfa için bottom değer 0.1 verilirse, doğrulama cümlesinin sayfanın altından uzaklığı 100 olur. Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  bottom: number | null;
/**
 * İmzalama cümlesi kutusunun lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir. Örnekler: "left top", "right top"
 * </summary>
 */
  transformOrigin: string;
}









/**
 * <summary>
 * CoreApi V2 istatistik sorgulama isteği.
 * Çağıran API key, kendi organizasyonundaki tüm API key'lerin istatistiklerini görebilir.
 * </summary>
 */
export interface ProxyGetCoreApiStatsRequest {
/**
 * <summary>
 * Başlangıç tarihi filtresi (opsiyonel). Belirtilirse bu tarihten itibaren olan işlemler dahil edilir.
 * </summary>
 */
  startDate: string | null;
/**
 * <summary>
 * Bitiş tarihi filtresi (opsiyonel). Belirtilirse bu tarihe kadar olan işlemler dahil edilir.
 * </summary>
 */
  endDate: string | null;
}






/**
 * <summary>
 * CoreApi V2 istatistik sonucu. Organizasyon geneli özet ve API key bazlı kırılım içerir.
 * </summary>
 */
export interface ProxyGetCoreApiStatsResult {
/**
 * <summary>
 * Organizasyon adı
 * </summary>
 */
  organizationName: string;
/**
 * <summary>
 * Uygulanan başlangıç tarihi filtresi
 * </summary>
 */
  startDate: string | null;
/**
 * <summary>
 * Uygulanan bitiş tarihi filtresi
 * </summary>
 */
  endDate: string | null;
/**
 * <summary>
 * Organizasyon genelindeki toplam işlem sayısı
 * </summary>
 */
  totalOperationCount: number;
/**
 * <summary>
 * Organizasyon genelindeki toplam hatalı işlem sayısı
 * </summary>
 */
  totalErrorCount: number;
/**
 * <summary>
 * Organizasyon genelindeki toplam dosya boyutu (byte)
 * </summary>
 */
  totalFileSizeBytes: number;
/**
 * <summary>
 * API key bazlı istatistik kırılımı
 * </summary>
 */
  apiUserStats: ProxyApiUserStatsItem[];
}






/**
 * <summary>
 * Tek bir API key (uygulama) için istatistik özeti.
 * </summary>
 */
export interface ProxyApiUserStatsItem {
/**
 * <summary>
 * API kullanıcısının Id'si
 * </summary>
 */
  apiUserId: number;
/**
 * <summary>
 * API kullanıcısının adı
 * </summary>
 */
  apiUserName: string;
/**
 * <summary>
 * API kullanıcısının aktif olup olmadığı
 * </summary>
 */
  isActive: boolean;
/**
 * <summary>
 * Bu API key ile yapılan toplam işlem sayısı
 * </summary>
 */
  totalOperationCount: number;
/**
 * <summary>
 * Bu API key ile yapılan toplam hatalı işlem sayısı
 * </summary>
 */
  totalErrorCount: number;
/**
 * <summary>
 * Bu API key ile işlenen toplam dosya boyutu (byte)
 * </summary>
 */
  totalFileSizeBytes: number;
/**
 * <summary>
 * İşlem tipi bazlı detaylı kırılım
 * </summary>
 */
  operationDetails: ProxyOperationTypeStatsItem[];
}






/**
 * <summary>
 * Belirli bir işlem tipi için istatistik detayı.
 * </summary>
 */
export interface ProxyOperationTypeStatsItem {
/**
 * <summary>
 * İşlem tipinin açıklaması (örn. "Pades İmza Başlatma")
 * </summary>
 */
  operationTypeDescription: string;
/**
 * <summary>
 * Bu işlem tipindeki toplam işlem sayısı
 * </summary>
 */
  count: number;
/**
 * <summary>
 * Bu işlem tipindeki hatalı işlem sayısı
 * </summary>
 */
  errorCount: number;
/**
 * <summary>
 * Bu işlem tipindeki toplam dosya boyutu (byte)
 * </summary>
 */
  totalFileSizeBytes: number;
}







/**
 * <summary>
 * CoreApi V2 işlem detayları sorgulama isteği.
 * Sayfalama ve filtreleme destekler.
 * </summary>
 */
export interface ProxyGetCoreApiOperationsRequest {
/**
 * <summary>
 * Başlangıç tarihi filtresi (opsiyonel)
 * </summary>
 */
  startDate: string | null;
/**
 * <summary>
 * Bitiş tarihi filtresi (opsiyonel)
 * </summary>
 */
  endDate: string | null;
/**
 * <summary>
 * Belirli bir API kullanıcısına ait işlemleri filtrelemek için (opsiyonel)
 * </summary>
 */
  apiUserId: number | null;
/**
 * <summary>
 * Belirli bir işlem tipine göre filtrelemek için (opsiyonel)
 * </summary>
 */
  operationType: number | null;
/**
 * <summary>
 * Sadece hatalı veya başarılı işlemleri filtrelemek için (opsiyonel). 
 * true = sadece hatalılar, false = sadece başarılılar, null = tümü
 * </summary>
 */
  hasError: boolean | null;
/**
 * <summary>
 * Sayfa numarası (1 tabanlı). Varsayılan: 1
 * </summary>
 */
  page: number;
/**
 * <summary>
 * Sayfa başı kayıt sayısı. Varsayılan: 50, Maksimum: 200
 * </summary>
 */
  pageSize: number;
}






/**
 * <summary>
 * CoreApi V2 işlem detayları sonucu. Sayfalanmış işlem listesi içerir.
 * </summary>
 */
export interface ProxyGetCoreApiOperationsResult {
/**
 * <summary>
 * Filtrelere uyan toplam kayıt sayısı
 * </summary>
 */
  totalCount: number;
/**
 * <summary>
 * Mevcut sayfa numarası
 * </summary>
 */
  page: number;
/**
 * <summary>
 * Sayfa başı kayıt sayısı
 * </summary>
 */
  pageSize: number;
/**
 * <summary>
 * İşlem kayıtları listesi
 * </summary>
 */
  operations: ProxyCoreApiOperationItem[];
}






/**
 * <summary>
 * Tek bir CoreApi V2 işlem kaydı.
 * </summary>
 */
export interface ProxyCoreApiOperationItem {
/**
 * <summary>
 * İşlem kimliği (GUID)
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * API kullanıcısının Id'si
 * </summary>
 */
  apiUserId: number;
/**
 * <summary>
 * API kullanıcısının adı
 * </summary>
 */
  apiUserName: string;
/**
 * <summary>
 * İşlem tipi enum değeri
 * </summary>
 */
  operationType: number;
/**
 * <summary>
 * İşlem tipinin açıklaması
 * </summary>
 */
  operationTypeDescription: string;
/**
 * <summary>
 * İşlem tarihi
 * </summary>
 */
  createdDate: string;
/**
 * <summary>
 * İşlemde hata oluşup oluşmadığı
 * </summary>
 */
  hasError: boolean;
/**
 * <summary>
 * Hata mesajı (varsa)
 * </summary>
 */
  error: string;
/**
 * <summary>
 * Çıktı dosyası boyutu (byte, varsa)
 * </summary>
 */
  outputFileSize: number | null;
}



    // ═══════════════════════════════════════════════════════════════

    // V4 CAdES PROXY MODELLERİ

    // ═══════════════════════════════════════════════════════════════







/**
 * <summary>
 * V4 CAdES e-imza atma işlemi için ilk adım isteği.
 * Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
 * </summary>
 */
export interface ProxyCreateStateOnOnaylarimApiForCadesRequestV4 {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır (Base64 DER veya PEM).
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * Her bir istek için tekil bir GUID değeri verilmelidir. Önceden upload edilmiş dosyanın OperationId'sidir.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Seri veya paralel imza atılıp atılacağını belirler, boş geçilirse PARALLEL imza atılır.
 * Olası değerler: SERIAL, PARALLEL
 * </summary>
 */
  serialOrParallel: string | null;
/**
 * <summary>
 * Seri imzada üzerine imza atılacak imzanın EntityLabel'ı (örn: S0, S0:S0).
 * Boş bırakılırsa son imza üzerine atılır. Parallel imzada yok sayılır.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * Hedef imza seviyesi. SignStepThree'de bu seviyeye upgrade edilir.
 * </summary>
 */
  signatureLevel: SignatureLevelForCadesV4;
/**
 * <summary>
 * Türk imza profili. EPES gerektiren seviyeler için zorunlu.
 * None veya P1: profilsiz BES tabanlı imza. P2/P3/P4: EPES tabanlı imza.
 * </summary>
 */
  profile: CadesProfileV4;
/**
 * <summary>
 * Hash algoritması. Varsayılan SHA256.
 * </summary>
 */
  hashAlgorithm: CadesHashAlgorithmV4;
/**
 * <summary>
 * true ise detached imza oluşturulur (orijinal veri .cms içine gömülmez).
 * </summary>
 */
  detached: boolean;
/**
 * <summary>
 * Detached imzalarda: orijinal dosyanın OperationId'si.
 * Detached imza oluşturuluyorsa zorunludur, aksi halde null/boş bırakılır.
 * </summary>
 */
  originalFileOperationId: string | null;
}







/**
 * <summary>
 * V4 CAdES e-imza atma işlemi için son adım isteği.
 * İstemcinin imzaladığı veri ile imza tamamlanır.
 * </summary>
 */
export interface ProxyFinishSignForCadesRequestV4 {
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri (Base64).
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. StepOne'dan döner.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. StepOne'dan döner.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * StepOne'daki OperationId.
 * </summary>
 */
  operationId: string;
}






/**
 * <summary>
 * V4 CAdES imzalı bir belgedeki imza bilgilerini sorgulamak için istek modeli.
 * </summary>
 */
export interface ProxyGetSignatureListCadesRequestV4 {
/**
 * <summary>
 * İmzaları okunacak dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Detached imzalarda: orijinal dosyanın OperationId'si (doğrulama için).
 * Attached imzalarda null/boş bırakılır.
 * </summary>
 */
  originalFileOperationId: string | null;
}






/**
 * <summary>
 * V4 CAdES imza listesi sorgulamasının sonucu.
 * </summary>
 */
export interface ProxyGetSignatureListCadesResultV4 {
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
/**
 * <summary>
 * Dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Dosyanın detached imza içerip içermediğini belirtir.
 * Client bu alanı okuyarak sonraki işlemlerde (imza/upgrade) OriginalFileOperationId göndermesi gerektiğini bilir.
 * </summary>
 */
  isDetached: boolean;
/**
 * <summary>
 * Dosyadaki imzaların detaylı bilgileri.
 * </summary>
 */
  signatures: ProxyCadesSignatureInfoV4[];
}







/**
 * <summary>
 * V4 CAdES imza zenginleştirme (upgrade) isteği.
 * Mevcut imzayı daha yüksek bir seviyeye yükseltir.
 * </summary>
 */
export interface ProxyUpgradeCadesRequestV4 {
/**
 * <summary>
 * Upgrade edilecek dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Hedef seviye (mevcut seviyeden yüksek olmalı).
 * </summary>
 */
  targetLevel: SignatureLevelForCadesV4;
/**
 * <summary>
 * Upgrade edilecek imzanın EntityLabel'ı (örn: S0).
 * Boş bırakılırsa ilk imza upgrade edilir.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * Detached imzalarda: orijinal dosyanın OperationId'si.
 * Attached imzalarda null/boş bırakılır.
 * </summary>
 */
  originalFileOperationId: string | null;
}






/**
 * <summary>
 * V4 CAdES tek bir imzanın detaylı bilgisi.
 * </summary>
 */
export interface ProxyCadesSignatureInfoV4 {
/**
 * <summary>
 * İmzanın etiket bilgisi (örn: S0, S0:S0).
 * </summary>
 */
  entityLabel: string;
/**
 * <summary>
 * İmza seviyesi (sayısal değer).
 * </summary>
 */
  level: string;
/**
 * <summary>
 * İmza seviyesinin metin karşılığı (örn: BES, T, XL, A).
 * </summary>
 */
  levelString: string;
/**
 * <summary>
 * İmza sahibinin RDN (Relative Distinguished Name) bilgisi.
 * </summary>
 */
  subjectRDN: string;
/**
 * <summary>
 * İmza sahibinin TC kimlik numarası (varsa).
 * </summary>
 */
  citizenshipNo: string | null;
/**
 * <summary>
 * İmzanın zaman damgalı olup olmadığı.
 * </summary>
 */
  timestamped: boolean;
/**
 * <summary>
 * İmza atılma zamanı (metin formatında).
 * </summary>
 */
  claimedSigningTime: string | null;
/**
 * <summary>
 * İmza atılma zamanı (DateTime formatında).
 * </summary>
 */
  claimedSigningTimeAsTime: string | null;
/**
 * <summary>
 * İmzanın kapsamı (scope).
 * </summary>
 */
  scope: number;
/**
 * <summary>
 * Üst imzanın EntityLabel'ı (seri imzalarda).
 * </summary>
 */
  parentEntity: string | null;
/**
 * <summary>
 * İmza profil adı (örn: P2, P3, P4).
 * </summary>
 */
  profileName: string | null;
/**
 * <summary>
 * İmza politika OID'si.
 * </summary>
 */
  policyOID: string | null;
/**
 * <summary>
 * İmzada kullanılan hash algoritması.
 * </summary>
 */
  hashAlgorithm: string | null;
/**
 * <summary>
 * İmzanın uzun vadeli doğrulama bilgisi içerip içermediği.
 * </summary>
 */
  containsLongTermInfo: boolean;
/**
 * <summary>
 * Son arşiv zaman damgası zamanı (varsa).
 * </summary>
 */
  lastArchivalTime: string | null;
/**
 * <summary>
 * Zaman damgası detay bilgisi.
 * </summary>
 */
  timestamp: ProxyTimestampInfoItemV4 | null;
/**
 * <summary>
 * Mevcut seviyeden yapılabilecek tüm upgrade seçenekleri (örn: ["T","C","X","XL","A"]).
 * En üst seviyede (A) boş liste döner.
 * </summary>
 */
  upgradeOptions: string[];
/**
 * <summary>
 * Profil uyumlu upgrade seçenekleri.
 * Profil yoksa null döner.
 * </summary>
 */
  profileRecommendedUpgrades: string[] | null;
/**
 * <summary>
 * Profil dışı upgrade seçenekleri (teknik olarak mümkün ama profil uyumsuz).
 * Profil yoksa null döner.
 * </summary>
 */
  profileIncompatibleUpgrades: string[] | null;
}






/**
 * <summary>
 * V4 CAdES zaman damgası detay bilgisi.
 * </summary>
 */
export interface ProxyTimestampInfoItemV4 {
/**
 * <summary>
 * Zaman damgasının etiket bilgisi.
 * </summary>
 */
  entityLabel: string;
/**
 * <summary>
 * Zaman damgası zamanı (metin formatında).
 * </summary>
 */
  time: string | null;
/**
 * <summary>
 * Zaman damgası zamanı (DateTime formatında).
 * </summary>
 */
  timeAsTime: string | null;
/**
 * <summary>
 * Zaman damgası otoritesinin (TSA) adı.
 * </summary>
 */
  tSAName: string | null;
/**
 * <summary>
 * Zaman damgasında kullanılan hash algoritması.
 * </summary>
 */
  hashAlgorithm: string | null;
/**
 * <summary>
 * Zaman damgası tipi (sayısal değer).
 * </summary>
 */
  timestampType: number;
/**
 * <summary>
 * Zaman damgası tipinin metin karşılığı.
 * </summary>
 */
  timestampTypeStr: string | null;
}











/**
 * <summary>
 * V4 PAdES e-imza atma işlemi için ilk adım isteği.
 * Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
 * PAdES'te detached mod ve serial/parallel kavramı yoktur.
 * </summary>
 */
export interface ProxyCreateStateOnOnaylarimApiForPadesRequestV4 {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır (Base64 DER veya PEM).
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * Önceden upload edilmiş PDF dosyasının OperationId'sidir.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Hedef imza seviyesi. SignStepThree'de bu seviyeye upgrade edilir.
 * </summary>
 */
  signatureLevel: SignatureLevelForPadesV4;
/**
 * <summary>
 * Türk imza profili. PAdES'te sadece P4 desteklenir.
 * None: profilsiz imza. P4: EPES tabanlı imza.
 * </summary>
 */
  profile: PadesProfileV4;
/**
 * <summary>
 * Hash algoritması. Varsayılan SHA256.
 * </summary>
 */
  hashAlgorithm: CadesHashAlgorithmV4;
/**
 * <summary>
 * Görsel imza widget bilgisi. null ise görünmez (invisible) imza atılır.
 * </summary>
 */
  signatureWidgetInfo: ProxySignatureWidgetInfo | null;
}







/**
 * <summary>
 * V4 PAdES e-imza atma işlemi için son adım isteği.
 * İstemcinin imzaladığı veri ile imza tamamlanır.
 * </summary>
 */
export interface ProxyFinishSignForPadesRequestV4 {
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri (Base64).
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. StepOne'dan döner.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. StepOne'dan döner.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * StepOne'daki OperationId.
 * </summary>
 */
  operationId: string;
}






/**
 * <summary>
 * V4 PAdES imzalı bir PDF belgedeki imza bilgilerini sorgulamak için istek modeli.
 * </summary>
 */
export interface ProxyGetSignatureListPadesRequestV4 {
/**
 * <summary>
 * İmzaları okunacak PDF dosyasının OperationId'si.
 * </summary>
 */
  operationId: string;
}






/**
 * <summary>
 * V4 PAdES imza listesi sorgulamasının sonucu.
 * </summary>
 */
export interface ProxyGetSignatureListPadesResultV4 {
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
/**
 * <summary>
 * Dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * PDF dosyasındaki imzaların detaylı bilgileri.
 * </summary>
 */
  signatures: ProxyPadesSignatureInfoV4[];
}







/**
 * <summary>
 * V4 PAdES imza zenginleştirme (upgrade) isteği.
 * NOT: B-LT'ye upgrade desteklenmez. B-LT için yeni imza atılmalıdır.
 * </summary>
 */
export interface ProxyUpgradePadesRequestV4 {
/**
 * <summary>
 * Upgrade edilecek PDF dosyasının OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Hedef seviye. B-T veya B-LTA olabilir. B-LT desteklenmez.
 * </summary>
 */
  targetLevel: SignatureLevelForPadesV4;
/**
 * <summary>
 * Upgrade edilecek imzanın EntityLabel'ı (örn: S0).
 * Boş bırakılırsa ilk imza upgrade edilir.
 * </summary>
 */
  signaturePath: string | null;
}







/**
 * <summary>
 * V4 PAdES tek bir imzanın detaylı bilgisi.
 * CAdES'ten farklı olarak Scope, ParentEntity ve LastArchivalTime alanları yoktur.
 * </summary>
 */
export interface ProxyPadesSignatureInfoV4 {
/**
 * <summary>
 * İmzanın etiket bilgisi (örn: S0).
 * </summary>
 */
  entityLabel: string;
/**
 * <summary>
 * İmza seviyesi (sayısal değer).
 * </summary>
 */
  level: string;
/**
 * <summary>
 * İmza seviyesinin metin karşılığı (örn: B-B, B-T, B-LT, B-LTA).
 * </summary>
 */
  levelString: string;
/**
 * <summary>
 * İmza sahibinin RDN (Relative Distinguished Name) bilgisi.
 * </summary>
 */
  subjectRDN: string;
/**
 * <summary>
 * İmza sahibinin TC kimlik numarası (varsa).
 * </summary>
 */
  citizenshipNo: string | null;
/**
 * <summary>
 * İmzanın zaman damgalı olup olmadığı.
 * </summary>
 */
  timestamped: boolean;
/**
 * <summary>
 * İmza atılma zamanı (metin formatında).
 * </summary>
 */
  claimedSigningTime: string | null;
/**
 * <summary>
 * İmza atılma zamanı (DateTime formatında).
 * </summary>
 */
  claimedSigningTimeAsTime: string | null;
/**
 * <summary>
 * İmza profil adı (örn: P4).
 * </summary>
 */
  profileName: string | null;
/**
 * <summary>
 * İmza politika OID'si.
 * </summary>
 */
  policyOID: string | null;
/**
 * <summary>
 * İmzada kullanılan hash algoritması.
 * </summary>
 */
  hashAlgorithm: string | null;
/**
 * <summary>
 * İmzanın uzun vadeli doğrulama bilgisi içerip içermediği.
 * </summary>
 */
  containsLongTermInfo: boolean;
/**
 * <summary>
 * Zaman damgası detay bilgisi.
 * </summary>
 */
  timestamp: ProxyTimestampInfoItemV4 | null;
/**
 * <summary>
 * Mevcut seviyeden yapılabilecek upgrade seçenekleri (örn: ["B-T","B-LTA"]).
 * NOT: B-LT'ye upgrade desteklenmez.
 * </summary>
 */
  upgradeOptions: string[];
/**
 * <summary>
 * Profil uyumlu upgrade seçenekleri. Profil yoksa null döner.
 * </summary>
 */
  profileRecommendedUpgrades: string[] | null;
/**
 * <summary>
 * Profil dışı upgrade seçenekleri. Profil yoksa null döner.
 * </summary>
 */
  profileIncompatibleUpgrades: string[] | null;
}







/**
 * <summary>
 * PDF üzerine görsel imza widget bilgisi.
 * Görünür imza atılmak istendiğinde konum, boyut, arka plan görseli ve metin satırları belirtilir.
 * </summary>
 */
export interface ProxySignatureWidgetInfo {
/**
 * <summary>
 * İmzanın pixel olarak genişliğidir.
 * </summary>
 */
  width: number;
/**
 * <summary>
 * İmzanın pixel olarak yüksekliğidir.
 * </summary>
 */
  height: number;
/**
 * <summary>
 * İmzanın sayfanın solundan olan uzaklığıdır (oran olarak).
 * Sayfa genişliği 1000 olan bir sayfa için 0.1 verilirse, uzaklık 100 olur.
 * Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  left: number | null;
/**
 * <summary>
 * İmzanın sayfanın sağından olan uzaklığıdır (oran olarak).
 * Left ve Right değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  right: number | null;
/**
 * <summary>
 * İmzanın sayfanın üstünden olan uzaklığıdır (oran olarak).
 * Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  top: number | null;
/**
 * <summary>
 * İmzanın sayfanın altından olan uzaklığıdır (oran olarak).
 * Top ve Bottom değerleri aynı anda kullanılmamalı, sadece biri kullanılmalıdır.
 * </summary>
 */
  bottom: number | null;
/**
 * <summary>
 * İmzanın lokasyonu için hangi parametrelerin kullanılması gerektiği bilgisidir.
 * Örnekler: "left top", "right top".
 * </summary>
 */
  transformOrigin: string;
/**
 * <summary>
 * İmza görselinde arka plan görseli olarak kullanılacak imajın datasıdır. İmaj jpg olmalıdır.
 * </summary>
 */
  imageBytes: number[];
/**
 * <summary>
 * İmza görselinin hangi sayfalara yerleştirileceği bilgisidir, 0'dan başlar.
 * </summary>
 */
  pagesToPlaceOn: number[];
/**
 * <summary>
 * İmza görseli içerisinde yazılacak metin satırlarıdır.
 * </summary>
 */
  lines: ProxyLineInfo[];
}







/**
 * <summary>
 * İmza görseli içerisindeki tek bir metin satırının bilgisi.
 * Font, renk, marjin ve metin ayarlarını içerir.
 * </summary>
 */
export interface ProxyLineInfo {
/**
 * <summary>
 * Satır içerisinde yazacak ifadedir.
 * </summary>
 */
  text: string;
/**
 * <summary>
 * Satırın sol marjinidir.
 * </summary>
 */
  leftMargin: number;
/**
 * <summary>
 * Satırın üst marjinidir.
 * </summary>
 */
  topMargin: number;
/**
 * <summary>
 * Satırın alt marjinidir.
 * </summary>
 */
  bottomMargin: number;
/**
 * <summary>
 * Satırın sağ marjinidir.
 * </summary>
 */
  rightMargin: number;
/**
 * <summary>
 * Satırın hangi font ile yazılacağını belirler. Arial, Tahoma gibi kullanınız.
 * </summary>
 */
  fontName: string;
/**
 * <summary>
 * Satırın hangi font büyüklüğü ile yazılacağını belirler.
 * </summary>
 */
  fontSize: number;
/**
 * <summary>
 * Satırın hangi font tipi ile yazılacağını belirler.
 * Olası değerler: Regular, Bold, Italic, Underline, Strikeout.
 * </summary>
 */
  fontStyle: string;
/**
 * <summary>
 * Satırın hangi renkle yazılacağını belirler. #FF00FF gibi kullanınız.
 * </summary>
 */
  colorHtml: string;
}













/**
 * <summary>
 * V4 XAdES e-imza atma işlemi için ilk adım isteği.
 * Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
 * </summary>
 */
export interface ProxyCreateStateOnOnaylarimApiForXadesRequestV4 {
/**
 * <summary>
 * Son kullanıcı bilgisayarında bulunan e-İmza Aracı vasıtasıyla alınan, e-imza atarken kullanılacak sertifikadır (Base64 DER veya PEM).
 * </summary>
 */
  certificate: string;
/**
 * <summary>
 * Önceden upload edilmiş dosyanın OperationId'sidir.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Seri veya paralel imza. Boş geçilirse PARALLEL.
 * SERIAL: Counter-sign (üst imzanın unsigned alanına).
 * PARALLEL: Co-sign (bağımsız yeni Signature elementi).
 * </summary>
 */
  serialOrParallel: string | null;
/**
 * <summary>
 * Seri imzada üzerine imza atılacak imzanın EntityLabel'ı (örn: S0).
 * Boş bırakılırsa son imza üzerine atılır. Parallel imzada yok sayılır.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * Hedef imza seviyesi. XAdES seviyeleri: BES, EPES, T, XL, A (C ve X yoktur).
 * </summary>
 */
  signatureLevel: SignatureLevelForXadesV4;
/**
 * <summary>
 * Türk imza profili. None veya P1: profilsiz BES. P2/P3/P4: EPES tabanlı imza.
 * </summary>
 */
  profile: XadesProfileV4;
/**
 * <summary>
 * Hash algoritması. Varsayılan SHA256.
 * </summary>
 */
  hashAlgorithm: CadesHashAlgorithmV4;
/**
 * <summary>
 * İmza modu.
 * Enveloped: İmza XML dokümanın içine gömülür (input XML olmalı).
 * Enveloping: Veri ds:Object elementi içine konur.
 * Detached: İmza ayrı dosyada.
 * </summary>
 */
  signatureMode: XadesSignatureModeV4;
/**
 * <summary>
 * Detached imzalarda: imza XML'indeki Reference URI değeri.
 * Örn: "belge.xml" → &lt;ds:Reference URI="belge.xml"&gt; olur.
 * Boş bırakılırsa sunucu tarafında dosya adından türetilir.
 * Sadece Detached modda anlamlıdır, diğer modlarda yok sayılır.
 * </summary>
 */
  detachedResourceUri: string | null;
/**
 * <summary>
 * Detached imzalarda: orijinal dosyanın OperationId'si.
 * Enveloped/Enveloping'de null.
 * </summary>
 */
  originalFileOperationId: string | null;
/**
 * <summary>
 * Enveloped modda çoklu imza için: XML'deki hedef elementin Id attribute'u.
 * Örn: "content-1" → Reference URI="#content-1" olur.
 * Boş ise URI="" ile tüm doküman imzalanır.
 * </summary>
 */
  envelopedContentElementId: string | null;
/**
 * <summary>
 * Enveloping imza durumunda, zarf içinde yer alan nesnenin MIME türü.
 * Boş bırakılırsa "text/xml" kullanılır.
 * Örnek değerler: "text/xml", "application/pdf", "application/octet-stream"
 * </summary>
 */
  envelopingObjectMimeType: string | null;
/**
 * <summary>
 * Enveloping imza durumunda, zarf içinde yer alan nesnenin Encoding özniteliği.
 * Boş bırakılırsa "http://www.w3.org/2000/09/xmldsig#base64" kullanılır.
 * </summary>
 */
  envelopingObjectEncoding: string | null;
}







/**
 * <summary>
 * V4 XAdES e-imza atma işlemi için son adım isteği.
 * İstemcinin imzaladığı veri ile imza tamamlanır.
 * </summary>
 */
export interface ProxyFinishSignForXadesRequestV4 {
/**
 * <summary>
 * e-İmza aracı tarafından imzalanmış veri (Base64).
 * </summary>
 */
  signedData: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait ID değeridir. StepOne'dan döner.
 * </summary>
 */
  keyId: string;
/**
 * <summary>
 * Mevcut e-imza işlemine ait KeySecret değeridir. StepOne'dan döner.
 * </summary>
 */
  keySecret: string;
/**
 * <summary>
 * StepOne'daki OperationId.
 * </summary>
 */
  operationId: string;
}






/**
 * <summary>
 * V4 XAdES imzalı bir belgedeki imza bilgilerini sorgulamak için istek modeli.
 * </summary>
 */
export interface ProxyGetSignatureListXadesRequestV4 {
/**
 * <summary>
 * İmzaları okunacak dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Detached imzalarda: orijinal dosyanın OperationId'si (doğrulama için).
 * Enveloped/Enveloping'de null/boş bırakılır.
 * </summary>
 */
  originalFileOperationId: string | null;
}






/**
 * <summary>
 * V4 XAdES imza listesi sorgulamasının sonucu.
 * </summary>
 */
export interface ProxyGetSignatureListXadesResultV4 {
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
/**
 * <summary>
 * Dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Dosyadaki imzaların detaylı bilgileri.
 * </summary>
 */
  signatures: ProxyXadesSignatureInfoV4[];
/**
 * <summary>
 * Dosyanın detached imza olup olmadığı.
 * </summary>
 */
  isDetached: boolean;
/**
 * <summary>
 * İmza modu: Enveloped, Enveloping, veya Detached.
 * </summary>
 */
  signatureMode: string | null;
}







/**
 * <summary>
 * V4 XAdES imza zenginleştirme (upgrade) isteği.
 * XAdES seviyeleri: T, XL, A. C ve X yoktur, BES→EPES yasak.
 * </summary>
 */
export interface ProxyUpgradeXadesRequestV4 {
/**
 * <summary>
 * Upgrade edilecek dosyanın OperationId'si.
 * </summary>
 */
  operationId: string;
/**
 * <summary>
 * Hedef seviye (mevcut seviyeden yüksek olmalı).
 * </summary>
 */
  targetLevel: SignatureLevelForXadesV4;
/**
 * <summary>
 * Upgrade edilecek imzanın EntityLabel'ı (örn: S0).
 * Boş bırakılırsa ilk imza upgrade edilir.
 * </summary>
 */
  signaturePath: string | null;
/**
 * <summary>
 * Detached imzalarda: orijinal dosyanın OperationId'si.
 * Enveloped/Enveloping'de null/boş bırakılır.
 * </summary>
 */
  originalFileOperationId: string | null;
}








/**
 * <summary>
 * V4 XAdES tek bir imzanın detaylı bilgisi.
 * CAdES'e göre Scope yok, SignatureMode eklendi.
 * PAdES'e göre ParentEntity ve LastArchivalTime var, SignatureMode eklendi.
 * </summary>
 */
export interface ProxyXadesSignatureInfoV4 {
/**
 * <summary>
 * İmzanın etiket bilgisi (örn: S0, S0:S0).
 * </summary>
 */
  entityLabel: string;
/**
 * <summary>
 * İmza seviyesi (sayısal değer).
 * </summary>
 */
  level: string;
/**
 * <summary>
 * İmza seviyesinin metin karşılığı (örn: BES, T, XL, A).
 * </summary>
 */
  levelString: string;
/**
 * <summary>
 * İmza sahibinin RDN (Relative Distinguished Name) bilgisi.
 * </summary>
 */
  subjectRDN: string;
/**
 * <summary>
 * İmza sahibinin TC kimlik numarası (varsa).
 * </summary>
 */
  citizenshipNo: string | null;
/**
 * <summary>
 * İmzanın zaman damgalı olup olmadığı.
 * </summary>
 */
  timestamped: boolean;
/**
 * <summary>
 * İmza atılma zamanı (metin formatında).
 * </summary>
 */
  claimedSigningTime: string | null;
/**
 * <summary>
 * İmza atılma zamanı (DateTime formatında).
 * </summary>
 */
  claimedSigningTimeAsTime: string | null;
/**
 * <summary>
 * Üst imzanın EntityLabel'ı (seri imzalarda).
 * </summary>
 */
  parentEntity: string | null;
/**
 * <summary>
 * İmza profil adı (örn: P2, P3, P4).
 * </summary>
 */
  profileName: string | null;
/**
 * <summary>
 * İmza politika OID'si.
 * </summary>
 */
  policyOID: string | null;
/**
 * <summary>
 * İmzada kullanılan hash algoritması.
 * </summary>
 */
  hashAlgorithm: string | null;
/**
 * <summary>
 * İmzanın uzun vadeli doğrulama bilgisi içerip içermediği.
 * </summary>
 */
  containsLongTermInfo: boolean;
/**
 * <summary>
 * Son arşiv zaman damgası zamanı (varsa).
 * </summary>
 */
  lastArchivalTime: string | null;
/**
 * <summary>
 * Zaman damgası detay bilgisi.
 * </summary>
 */
  timestamp: ProxyTimestampInfoItemV4 | null;
/**
 * <summary>
 * İmza modu: Enveloped, Enveloping, veya Detached.
 * </summary>
 */
  signatureMode: string;
/**
 * <summary>
 * Mevcut seviyeden yapılabilecek upgrade seçenekleri (örn: ["T","XL","A"]).
 * XAdES'te C ve X seviyeleri yoktur.
 * </summary>
 */
  upgradeOptions: string[];
/**
 * <summary>
 * Profil uyumlu upgrade seçenekleri. Profil yoksa null döner.
 * </summary>
 */
  profileRecommendedUpgrades: string[] | null;
/**
 * <summary>
 * Profil dışı upgrade seçenekleri. Profil yoksa null döner.
 * </summary>
 */
  profileIncompatibleUpgrades: string[] | null;
}









// Generated by xxx.ps1 on 2026-02-22 21:13:17








export enum SignatureLevelForPades {
  //paslUnknown = 0,
  //paslGeneric = 1,
  //paslBaselineB = 2,
  //paslBaselineT = 3,
  //paslBaselineLT = 4,
  //paslBaselineLTA = 5,
  paslBES = 6,
  //paslEPES = 7,
  paslLTV = 8
}



export enum SignatureLevelForCades {
  aslBES = 6,                 // BES (Basic Electronic Signature)
  //aslEPES = 7,                // EPES (Electronic Signature with an Explicit Policy)
  aslT = 8,                   // T (Timestamped)
  //aslC = 9,                   // C (T with revocation references)
  //aslXType1 = 11,             // X Type 1 (C with an ES-C timestamp, CAdES only)
  //aslXType2 = 12,             // X Type 2 (C with a CertsAndCRLs timestamp, CAdES only)
  //aslXLType1 = 14,            // X-L Type 1 (C with revocation values and an ES-C timestamp, CAdES only)
  aslXLType2 = 15,            // X-L Type 2 (C with revocation values and a CertsAndCRLs timestamp, CAdES only)
  //aslA = 16,                  // A (archived)
  //aslExtendedBES = 17,        // Extended BES
  //aslExtendedEPES = 18,       // Extended EPES
  //aslExtendedT = 19,          // Extended T
  //aslExtendedC = 20,          // Extended C
  //aslExtendedXType1 = 22,     // Extended X (type 1, CAdES only)
  //aslExtendedXType2 = 23,     // Extended X (type 2, CAdES only)
  //aslExtendedXLType1 = 26,    // Extended XL (type 1, CAdES only)
  //aslExtendedXLType2 = 27,    // Extended XL (type 2, CAdES only)
  //aslExtendedA = 28           // Extended A
}





export enum SignatureLevelForXades {
  //aslUnknown = 0,
  //aslGeneric = 1,// Generic (this value applicable to XAdES signature only and corresponds to XML-DSIG signature)
  //aslBaselineB = 2,// Baseline B (B-B, basic)
  aslBaselineT = 3,// Baseline T (B-T, timestamped)
  aslBaselineLT = 4,// Baseline LT (B-LT, long-term)
  //aslBaselineLTA = 5,// Baseline LTA (B-LTA, long-term with archived timestamp)
  aslBES = 6,// BES (Basic Electronic Signature)
  //aslEPES = 7,// EPES (Electronic Signature with an Explicit Policy)
  //aslT = 8,//T,// (Timestamped)
  //aslC = 9,// C,// (T with revocation references)
  //aslX = 10,// X,// (C with SigAndRefs timestamp or RefsOnly timestamp) (this value applicable to XAdES signature only)
  //aslXL = 13,//	X-L (X with revocation values) (this value applicable to XAdES signature only)
  //aslA = 16,//	A (archived)
  //aslExtendedBES = 17,//	Extended BES
  //aslExtendedEPES = 18,//	Extended EPES
  //aslExtendedT = 19,//	Extended T
  //aslExtendedC = 20,//	Extended C
  //aslExtendedX = 21,//	Extended X (this value applicable to XAdES signature only)
  //aslExtendedXLong = 24,//	Extended X-Long (this value applicable to XAdES signature only)
  //aslExtendedXL = 25,//Extended X-L (this value applicable to XAdES signature only)
  //aslExtendedA = 28,//Extended A
}








/**
 * <summary>
 * V4 CAdES imza seviyeleri. Tüm CAdES seviyeleri desteklenir.
 * </summary>
 */
export enum SignatureLevelForCadesV4 {
// [Description("BES - Basic Electronic Signature")]
  BES = 1,
// [Description("EPES - Electronic Signature with Explicit Policy")]
  EPES = 2,
// [Description("ES-T - Timestamped")]
  T = 3,
// [Description("ES-C - T with revocation references")]
  C = 4,
// [Description("ES-X - C with timestamp")]
  X = 5,
// [Description("ES-XL - X with revocation values")]
  XL = 6,
// [Description("ES-A - Archived")]
  A = 7
}








/**
 * <summary>
 * Türk Elektronik İmza Kullanım Profilleri (Rehber v1.0).
 * </summary>
 */
export enum CadesProfileV4 {
// [Description("Profil yok")]
  None = 0,
// [Description("P1 - Sadece BES, policy yok")]
  P1 = 1,
// [Description("P2 - EPES+T, SİL (CRL), OID: 2.16.792.1.61.0.1.5070.3.1.1")]
  P2 = 2,
// [Description("P3 - EPES+XL/A, SİL (CRL), OID: 2.16.792.1.61.0.1.5070.3.2.1")]
  P3 = 3,
// [Description("P4 - EPES+XL/A, ÇİSDuP (OCSP), OID: 2.16.792.1.61.0.1.5070.3.3.1")]
  P4 = 4
}








/**
 * <summary>
 * V4 CAdES hash algoritmaları.
 * </summary>
 */
export enum CadesHashAlgorithmV4 {
// [Description("SHA-256")]
  SHA256 = 0,
// [Description("SHA-384")]
  SHA384 = 1,
// [Description("SHA-512")]
  SHA512 = 2
}









/**
 * <summary>
 * V4 PAdES imza seviyeleri (Baseline profili).
 * PAdES'te C/X seviyeleri yoktur - DSS dictionary ile doğrudan B-LT/B-LTA'ya geçilir.
 * </summary>
 */
export enum SignatureLevelForPadesV4 {
// [Description("B-B - Baseline Basic")]
  BB = 1,
// [Description("B-T - Baseline Timestamp")]
  BT = 2,
// [Description("B-LT - Baseline Long-Term")]
  BLT = 3,
// [Description("B-LTA - Baseline Long-Term Archival")]
  BLTA = 4
}










/**
 * <summary>
 * V4 PAdES Türk profilleri.
 * PAdES'te sadece P4 profili desteklenir (Rehber v1.0).
 * P1/P2/P3 profilleri sadece CAdES/XAdES'te geçerlidir.
 * </summary>
 */
export enum PadesProfileV4 {
// [Description("Profil yok")]
  None = 0,
// [Description("P3 - EPES+B-LT/B-LTA, SİL (CRL), OID: 2.16.792.1.61.0.1.5070.3.2.1")]
  P3 = 3,
// [Description("P4 - EPES+B-LT/B-LTA, ÇİSDuP (OCSP), OID: 2.16.792.1.61.0.1.5070.3.3.1")]
  P4 = 4
}










/**
 * <summary>
 * V4 XAdES imza seviyeleri. XAdES'te C ve X seviyeleri yoktur.
 * BES, EPES, T, XL, A desteklenir.
 * Numara değerleri CAdES ile tutarlı (C=4, X=5 atlanıyor).
 * </summary>
 */
export enum SignatureLevelForXadesV4 {
// [Description("BES - Basic Electronic Signature")]
  BES = 1,
// [Description("EPES - Electronic Signature with Explicit Policy")]
  EPES = 2,
// [Description("ES-T - Timestamped")]
  T = 3,
// [Description("ES-XL - Extended Long-Term (revocation values dahil)")]
  XL = 6,
// [Description("ES-A - Archived")]
  A = 7
}










/**
 * <summary>
 * XAdES Türk Elektronik İmza Kullanım Profilleri (Rehber v1.0).
 * CAdES ile aynı profiller ve OID'ler.
 * P1: BES only, P2: T only, P3/P4: XL/A
 * </summary>
 */
export enum XadesProfileV4 {
// [Description("Profil yok")]
  None = 0,
// [Description("P1 - Sadece BES, policy yok")]
  P1 = 1,
// [Description("P2 - EPES+T, SİL (CRL), OID: 2.16.792.1.61.0.1.5070.3.1.1")]
  P2 = 2,
// [Description("P3 - EPES+XL/A, SİL (CRL), OID: 2.16.792.1.61.0.1.5070.3.2.1")]
  P3 = 3,
// [Description("P4 - EPES+XL/A, ÇİSDuP (OCSP), OID: 2.16.792.1.61.0.1.5070.3.3.1")]
  P4 = 4
}












/**
 * <summary>
 * XAdES imza modu.
 * CAdES'teki bool Detached yerine üç mod desteklenir.
 * Enveloped: İmza XML dokümanın içine gömülür (input XML olmalı).
 * Enveloping: Veri imzanın ds:Object elementi içine konur.
 * Detached: İmza ayrı dosyada, veri harici referansla işaret edilir.
 * </summary>
 */
export enum XadesSignatureModeV4 {
// [Description("Enveloped - İmza XML dokümanın içine gömülü")]
  Enveloped = 0,
// [Description("Enveloping - Veri imzanın içine konur (ds:Object)")]
  Enveloping = 1,
// [Description("Detached - İmza ayrı dosyada")]
  Detached = 2
}








