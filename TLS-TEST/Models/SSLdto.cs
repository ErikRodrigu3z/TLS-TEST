using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLS_TEST.Models
{     
    public class SSLdto
    {
        public string host { get; set; }
        public int port { get; set; }
        public string protocol { get; set; }
        public bool isPublic { get; set; }
        public string status { get; set; }
        public long startTime { get; set; }
        public long testTime { get; set; }
        public string engineVersion { get; set; }
        public string criteriaVersion { get; set; }
        public int cacheExpiryTime { get; set; }
        public Endpoint[] endpoints { get; set; }
        public object[] certHostnames { get; set; }
    }

    public class Endpoint
    {
        public string ipAddress { get; set; }
        public string serverName { get; set; }
        public string statusMessage { get; set; }
        public string grade { get; set; }
        public string gradeTrustIgnored { get; set; }
        public bool hasWarnings { get; set; }
        public bool isExceptional { get; set; }
        public int progress { get; set; }
        public int duration { get; set; }
        public int eta { get; set; }
        public int delegation { get; set; }
        public Details details { get; set; }
    }

    public class Details
    {
        public long hostStartTime { get; set; }
        public Key key { get; set; }
        public Cert cert { get; set; }
        public Chain chain { get; set; }
        public Protocol[] protocols { get; set; }
        public Suites suites { get; set; }
        public string serverSignature { get; set; }
        public bool prefixDelegation { get; set; }
        public bool nonPrefixDelegation { get; set; }
        public bool vulnBeast { get; set; }
        public int renegSupport { get; set; }
        public string stsResponseHeader { get; set; }
        public int stsMaxAge { get; set; }
        public bool stsSubdomains { get; set; }
        public object pkpResponseHeader { get; set; }
        public int sessionResumption { get; set; }
        public int compressionMethods { get; set; }
        public bool supportsNpn { get; set; }
        public string npnProtocols { get; set; }
        public int sessionTickets { get; set; }
        public bool ocspStapling { get; set; }
        public int staplingRevocationStatus { get; set; }
        public bool sniRequired { get; set; }
        public int httpStatusCode { get; set; }
        public string httpForwarding { get; set; }
        public bool supportsRc4 { get; set; }
        public bool rc4WithModern { get; set; }
        public bool rc4Only { get; set; }
        public int forwardSecrecy { get; set; }
        public int protocolIntolerance { get; set; }
        public int miscIntolerance { get; set; }
        public Sims sims { get; set; }
        public bool heartbleed { get; set; }
        public bool heartbeat { get; set; }
        public int openSslCcs { get; set; }
        public int openSSLLuckyMinus20 { get; set; }
        public bool poodle { get; set; }
        public int poodleTls { get; set; }
        public bool fallbackScsv { get; set; }
        public bool freak { get; set; }
        public int hasSct { get; set; }
        public object dhPrimes { get; set; }
        public int dhUsesKnownPrimes { get; set; }
        public bool dhYsReuse { get; set; }
        public bool logjam { get; set; }
        public bool chaCha20Preference { get; set; }
        public Hstspolicy hstsPolicy { get; set; }
        public Hstspreload[] hstsPreloads { get; set; }
        public Hpkppolicy hpkpPolicy { get; set; }
        public Hpkpropolicy hpkpRoPolicy { get; set; }
        public object[] drownHosts { get; set; }
        public bool drownErrors { get; set; }
        public bool drownVulnerable { get; set; }
    }

    public class Key
    {
        public int size { get; set; }
        public int strength { get; set; }
        public string alg { get; set; }
        public bool debianFlaw { get; set; }
    }

    public class Cert
    {
        public string subject { get; set; }
        public string[] commonNames { get; set; }
        public string[] altNames { get; set; }
        public long notBefore { get; set; }
        public long notAfter { get; set; }
        public string issuerSubject { get; set; }
        public string sigAlg { get; set; }
        public string issuerLabel { get; set; }
        public int revocationInfo { get; set; }
        public string[] crlURIs { get; set; }
        public string[] ocspURIs { get; set; }
        public int revocationStatus { get; set; }
        public int crlRevocationStatus { get; set; }
        public int ocspRevocationStatus { get; set; }
        public int sgc { get; set; }
        public int issues { get; set; }
        public bool sct { get; set; }
        public int mustStaple { get; set; }
    }

    public class Chain
    {
        public Cert1[] certs { get; set; }
        public int issues { get; set; }
    }

    public class Cert1
    {
        public string subject { get; set; }
        public string label { get; set; }
        public long notBefore { get; set; }
        public long notAfter { get; set; }
        public string issuerSubject { get; set; }
        public string issuerLabel { get; set; }
        public string sigAlg { get; set; }
        public int issues { get; set; }
        public string keyAlg { get; set; }
        public int keySize { get; set; }
        public int keyStrength { get; set; }
        public int revocationStatus { get; set; }
        public int crlRevocationStatus { get; set; }
        public int ocspRevocationStatus { get; set; }
        public string raw { get; set; }
    }

    public class Suites
    {
        public List[] list { get; set; }
        public bool preference { get; set; }
    }

    public class List
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cipherStrength { get; set; }
        public int ecdhBits { get; set; }
        public int ecdhStrength { get; set; }
    }

    public class Sims
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public Client client { get; set; }
        public int errorCode { get; set; }
        public int attempts { get; set; }
        public int protocolId { get; set; }
        public int suiteId { get; set; }
    }

    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public bool isReference { get; set; }
        public string platform { get; set; }
    }

    public class Hstspolicy
    {
        public int LONG_MAX_AGE { get; set; }
        public object header { get; set; }
        public int status { get; set; }
        public object error { get; set; }
        public object maxAge { get; set; }
        public bool includeSubDomains { get; set; }
        public bool preload { get; set; }
        public Directives directives { get; set; }
    }

    public class Directives
    {
    }

    public class Hpkppolicy
    {
        public int status { get; set; }
        public object header { get; set; }
        public object error { get; set; }
        public int maxAge { get; set; }
        public bool includeSubDomains { get; set; }
        public object reportUri { get; set; }
        public object[] pins { get; set; }
        public object[] matchedPins { get; set; }
        public Directives1 directives { get; set; }
    }

    public class Directives1
    {
    }

    public class Hpkpropolicy
    {
        public int status { get; set; }
        public object header { get; set; }
        public object error { get; set; }
        public int maxAge { get; set; }
        public bool includeSubDomains { get; set; }
        public object reportUri { get; set; }
        public object[] pins { get; set; }
        public object[] matchedPins { get; set; }
        public Directives2 directives { get; set; }
    }

    public class Directives2
    {
    }

    public class Protocol
    {
        public int id { get; set; }
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Hstspreload
    {
        public string source { get; set; }
        public int status { get; set; }
        public object error { get; set; }
        public long sourceTime { get; set; }
    }













}
