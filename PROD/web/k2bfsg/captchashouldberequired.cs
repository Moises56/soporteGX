using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class captchashouldberequired : GXProcedure
   {
      public captchashouldberequired( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public captchashouldberequired( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_LogOnTo ,
                           string aP1_UserName ,
                           out bool aP2_IncorrectLoginsExisted )
      {
         this.AV16LogOnTo = aP0_LogOnTo;
         this.AV17UserName = aP1_UserName;
         this.AV15IncorrectLoginsExisted = false ;
         initialize();
         executePrivate();
         aP2_IncorrectLoginsExisted=this.AV15IncorrectLoginsExisted;
      }

      public bool executeUdp( string aP0_LogOnTo ,
                              string aP1_UserName )
      {
         execute(aP0_LogOnTo, aP1_UserName, out aP2_IncorrectLoginsExisted);
         return AV15IncorrectLoginsExisted ;
      }

      public void executeSubmit( string aP0_LogOnTo ,
                                 string aP1_UserName ,
                                 out bool aP2_IncorrectLoginsExisted )
      {
         captchashouldberequired objcaptchashouldberequired;
         objcaptchashouldberequired = new captchashouldberequired();
         objcaptchashouldberequired.AV16LogOnTo = aP0_LogOnTo;
         objcaptchashouldberequired.AV17UserName = aP1_UserName;
         objcaptchashouldberequired.AV15IncorrectLoginsExisted = false ;
         objcaptchashouldberequired.context.SetSubmitInitialConfig(context);
         objcaptchashouldberequired.initialize();
         Submit( executePrivateCatch,objcaptchashouldberequired);
         aP2_IncorrectLoginsExisted=this.AV15IncorrectLoginsExisted;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((captchashouldberequired)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV23AmountOfCharacters, out  AV21AmountOfFailedLogins, out  AV20BadLoginsExpire, out  AV22ShouldAddSleepOnFailure) ;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV8CaptchaRequiredText) ;
         if ( StringUtil.StrCmp(AV8CaptchaRequiredText, "true") == 0 )
         {
            AV15IncorrectLoginsExisted = true;
         }
         else
         {
            AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV16LogOnTo, AV17UserName, out  AV14GetUserErrors);
            if ( AV14GetUserErrors.Count == 0 )
            {
               AV11FoundLoginAttempts = false;
               AV10FoundLastLoginAttempt = false;
               AV13GAMUserAttribute = AV12GAMUser.getattribute("LoginAttempts", out  AV9Errors);
               if ( AV9Errors.Count == 0 )
               {
                  AV11FoundLoginAttempts = true;
                  AV18LoginAttempts = (short)(Math.Round(NumberUtil.Val( AV13GAMUserAttribute.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               AV13GAMUserAttribute = AV12GAMUser.getattribute("LastLoginAttempt", out  AV9Errors);
               if ( AV9Errors.Count == 0 )
               {
                  AV10FoundLastLoginAttempt = true;
                  AV19LastLoginAttemptDateTime = context.localUtil.CToT( AV13GAMUserAttribute.gxTpr_Value, 1);
               }
               if ( AV20BadLoginsExpire )
               {
                  if ( AV11FoundLoginAttempts )
                  {
                     if ( AV10FoundLastLoginAttempt )
                     {
                        if ( DateTimeUtil.TAdd( AV19LastLoginAttemptDateTime, 3600*(1)) <= DateTimeUtil.ServerNow( context, pr_default) )
                        {
                           AV15IncorrectLoginsExisted = false;
                        }
                        else
                        {
                           if ( AV18LoginAttempts >= AV21AmountOfFailedLogins )
                           {
                              if ( AV22ShouldAddSleepOnFailure )
                              {
                                 new GeneXus.Programs.k2bfsg.sleepafterincorrectlogin(context ).execute( ref  AV18LoginAttempts) ;
                              }
                              AV15IncorrectLoginsExisted = true;
                           }
                        }
                     }
                  }
               }
               else
               {
                  if ( AV11FoundLoginAttempts )
                  {
                     if ( AV18LoginAttempts >= AV21AmountOfFailedLogins )
                     {
                        if ( AV22ShouldAddSleepOnFailure )
                        {
                           new GeneXus.Programs.k2bfsg.sleepafterincorrectlogin(context ).execute( ref  AV18LoginAttempts) ;
                        }
                        AV15IncorrectLoginsExisted = true;
                     }
                  }
               }
            }
            else
            {
               AV15IncorrectLoginsExisted = false;
            }
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8CaptchaRequiredText = "";
         AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV14GetUserErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
         AV9Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV19LastLoginAttemptDateTime = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.captchashouldberequired__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23AmountOfCharacters ;
      private short AV21AmountOfFailedLogins ;
      private short AV18LoginAttempts ;
      private string AV16LogOnTo ;
      private string AV8CaptchaRequiredText ;
      private DateTime AV19LastLoginAttemptDateTime ;
      private bool AV15IncorrectLoginsExisted ;
      private bool AV20BadLoginsExpire ;
      private bool AV22ShouldAddSleepOnFailure ;
      private bool AV11FoundLoginAttempts ;
      private bool AV10FoundLastLoginAttempt ;
      private string AV17UserName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_IncorrectLoginsExisted ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GetUserErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserAttribute AV13GAMUserAttribute ;
   }

   public class captchashouldberequired__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
