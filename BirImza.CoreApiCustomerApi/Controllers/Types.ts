





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
  serialOrParallel: string;
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




// Generated by xxx.ps1 on 2025-12-15 16:19:35







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
  aslA = 16,                  // A (archived)
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
  //aslBaselineT = 3,// Baseline T (B-T, timestamped)
  //aslBaselineLT = 4,// Baseline LT (B-LT, long-term)
  //aslBaselineLTA = 5,// Baseline LTA (B-LTA, long-term with archived timestamp)
  aslBES = 6,// BES (Basic Electronic Signature)
  //aslEPES = 7,// EPES (Electronic Signature with an Explicit Policy)
  aslT = 8,//T,// (Timestamped)
  //aslC = 9,// C,// (T with revocation references)
  //aslX = 10,// X,// (C with SigAndRefs timestamp or RefsOnly timestamp) (this value applicable to XAdES signature only)
  aslXL = 13,//	X-L (X with revocation values) (this value applicable to XAdES signature only)
  aslA = 16,//	A (archived)
  //aslExtendedBES = 17,//	Extended BES
  //aslExtendedEPES = 18,//	Extended EPES
  //aslExtendedT = 19,//	Extended T
  //aslExtendedC = 20,//	Extended C
  //aslExtendedX = 21,//	Extended X (this value applicable to XAdES signature only)
  //aslExtendedXLong = 24,//	Extended X-Long (this value applicable to XAdES signature only)
  //aslExtendedXL = 25,//Extended X-L (this value applicable to XAdES signature only)
  //aslExtendedA = 28,//Extended A
}








