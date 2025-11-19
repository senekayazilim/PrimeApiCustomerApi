namespace BirImza.Types.Shared
{
    public enum SignatureLevelForPades
    {
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
    public enum SignatureLevelForCades
    {
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
}
