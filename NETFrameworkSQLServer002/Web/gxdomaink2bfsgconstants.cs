using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomaink2bfsgconstants
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bfsgconstants ()
      {
         domain["LoginAttempts"] = "Login Attempts";
         domain["LastLoginAttempt"] = "Last Login Attempt";
         domain["SessionCaptchaIteSessionCaptchaItem"] = "Session Captcha Item";
         domain["SessionCaptchaActive"] = "Session Captcha Active";
         domain["SessionUserRememberMe"] = "SessionUserRememberMe";
         domain["LastPasswordRecoveryEmailDate"] = "Last Password Recovery Email Date";
         domain["ConfSendPasswordMail"] = "ConfSendPasswordMail";
         domain["ConfMailSubject"] = "Conf Mail Subject";
         domain["ConfMailMessage"] = "Conf Mail Message";
         domain["ConfSMTPServerName"] = "ConfSMTPServerName";
         domain["ConfSMTPUserName"] = "Conf SMTPUser Name";
         domain["ConfSMTPPassword"] = "Conf SMTPPassword";
         domain["ConfSMTPPort"] = "Conf SMTPPort";
         domain["ConfSMTPAuthentication"] = "Conf SMTPAuthentication";
         domain["ConfSMTPSenderName"] = "Conf SMTPSender Name";
         domain["ConfSMTPSenderAddress"] = "Conf SMTPSender Address";
         domain["ConfMinMinutesBetweenEmails"] = "Conf Min Minutes Between Emails";
         domain["ConfServerHost"] = "Conf Server Host";
         domain["ConfServerPort"] = "Conf Server Port";
         domain["ConfServerBaseURL"] = "Conf Server Base URL";
         domain["JavaGenerator"] = "JavaGenerator";
         domain["CSharpGenerator"] = "CSharpGenerator";
         domain["SessionCaptchaRedirectURL"] = "SessionCaptchaRedirectURL";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return context.GetMessage( value, "") ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["LoginAttempts"] = "LoginAttempts";
            domainMap["LastLoginAttempt"] = "LastLoginAttempt";
            domainMap["SessionCaptchaItem"] = "SessionCaptchaIteSessionCaptchaItem";
            domainMap["SessionCaptchaActive"] = "SessionCaptchaActive";
            domainMap["SessionUserRememberMe"] = "SessionUserRememberMe";
            domainMap["LastPasswordRecoveryEmailDate"] = "LastPasswordRecoveryEmailDate";
            domainMap["ConfSendPasswordMail"] = "ConfSendPasswordMail";
            domainMap["ConfMailSubject"] = "ConfMailSubject";
            domainMap["ConfMailMessage"] = "ConfMailMessage";
            domainMap["ConfSMTPServerName"] = "ConfSMTPServerName";
            domainMap["ConfSMTPUserName"] = "ConfSMTPUserName";
            domainMap["ConfSMTPPassword"] = "ConfSMTPPassword";
            domainMap["ConfSMTPPort"] = "ConfSMTPPort";
            domainMap["ConfSMTPAuthentication"] = "ConfSMTPAuthentication";
            domainMap["ConfSMTPSenderName"] = "ConfSMTPSenderName";
            domainMap["ConfSMTPSenderAddress"] = "ConfSMTPSenderAddress";
            domainMap["ConfMinMinutesBetweenEmails"] = "ConfMinMinutesBetweenEmails";
            domainMap["ConfServerHost"] = "ConfServerHost";
            domainMap["ConfServerPort"] = "ConfServerPort";
            domainMap["ConfServerBaseURL"] = "ConfServerBaseURL";
            domainMap["JavaGenerator"] = "JavaGenerator";
            domainMap["CSharpGenerator"] = "CSharpGenerator";
            domainMap["SessionCaptchaRedirectURL"] = "SessionCaptchaRedirectURL";
         }
         return (string)domainMap[key] ;
      }

   }

}
