




export interface CreateStateOnOnaylarimApiRequest {
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



export interface CreateStateOnOnaylarimApiResult {
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





export interface GetFingerPrintRequest {
  operationId: string;
}



export interface GetFingerPrintResult {
  fingerPrint: string;
}



export interface FinishSignRequest {
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



export interface FinishSignResult {
/**
 * <summary>
 * İşlemin başarıyla tamamlanıp tamamlanmadığını gösterir
 * </summary>
 */
  isSuccess: boolean;
}



export interface MobilSignResult {
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



export interface UploadFileResult {
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



export interface MobileSignRequest {
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



export interface MobileSignRequestV2 {
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
}



export interface GetSignatureListResult {
/**
 * <summary>
 * Hata var ise detay bilgisi döner.
 * </summary>
 */
  error: string;
  signatures: Array<GetSignatureListResultItem>;
}



export interface GetSignatureListResultItem {
  entityLabel: string;
  level: number;
  levelString: string;
  subjectRDN: string;
  timestamped: boolean;
  claimedSigningTime: string;
  citizenshipNo: string | null;
}




// Generated by xxx.ps1 on 2025-11-19 16:00:32







export enum SignatureLevelForPades {
  //paslUnknown = 0,
  //paslGeneric = 1,
  paslBaselineB = 2,
  paslBaselineT = 3,
  paslBaselineLT = 4,
  paslBaselineLTA = 5,
  paslBES = 6,
  paslEPES = 7,
  paslLTV = 8
}



export enum SignatureLevelForCades {
  aslBES = 6,                 // BES (Basic Electronic Signature)
  aslEPES = 7,                // EPES (Electronic Signature with an Explicit Policy)
  aslT = 8,                   // T (Timestamped)
  aslC = 9,                   // C (T with revocation references)
  aslXType1 = 11,             // X Type 1 (C with an ES-C timestamp, CAdES only)
  aslXType2 = 12,             // X Type 2 (C with a CertsAndCRLs timestamp, CAdES only)
  aslXLType1 = 14,            // X-L Type 1 (C with revocation values and an ES-C timestamp, CAdES only)
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








