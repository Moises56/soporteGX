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
   public class sendrecoveryemail : GXProcedure
   {
      public sendrecoveryemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public sendrecoveryemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserName ,
                           string aP1_IDP_State )
      {
         this.AV15UserName = aP0_UserName;
         this.AV14IDP_State = aP1_IDP_State;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_UserName ,
                                 string aP1_IDP_State )
      {
         sendrecoveryemail objsendrecoveryemail;
         objsendrecoveryemail = new sendrecoveryemail();
         objsendrecoveryemail.AV15UserName = aP0_UserName;
         objsendrecoveryemail.AV14IDP_State = aP1_IDP_State;
         objsendrecoveryemail.context.SetSubmitInitialConfig(context);
         objsendrecoveryemail.initialize();
         Submit( executePrivateCatch,objsendrecoveryemail);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sendrecoveryemail)stateInfo).executePrivate();
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
         AV10User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV16UserAuthTypeName, AV15UserName, out  AV11Errors);
         AV9Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV8LinkURL = StringUtil.Trim( AV9Application.gxTpr_Environment.gxTpr_Url) + formatLink("k2bfsg.recoverpasswordstep2.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(AV14IDP_State)),GXUtil.UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDP_State","KeyToChangePassword"}) ;
         AV8LinkURL += "%1";
         AV10User.sendemailtorecoverpassword( AV9Application,  AV8LinkURL, out  AV11Errors);
         if ( AV11Errors.Count == 0 )
         {
            /* Execute user subroutine: 'SETLASTEMAILSENTTIMETONOW' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            context.CommitDataStores("k2bfsg.sendrecoveryemail",pr_default);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SETLASTEMAILSENTTIMETONOW' Routine */
         returnInSub = false;
         AV12GAMUserAttribute = AV10User.getattribute("LastPasswordRecoveryEmailDate", out  AV11Errors);
         if ( AV11Errors.Count == 0 )
         {
            AV13LastEmailSent = DateTimeUtil.ServerNow( context, pr_default);
            AV12GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV13LastEmailSent, 8, 5, 1, 2, "/", ":", " ");
            AV10User.setattribute( AV12GAMUserAttribute, out  AV11Errors);
         }
         else
         {
            AV12GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
            AV12GAMUserAttribute.gxTpr_Id = "LastPasswordRecoveryEmailDate";
            AV13LastEmailSent = DateTimeUtil.ServerNow( context, pr_default);
            AV12GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV13LastEmailSent, 8, 5, 1, 2, "/", ":", " ");
            AV12GAMUserAttribute.gxTpr_Ismultivalue = false;
            AV10User.setattribute( AV12GAMUserAttribute, out  AV11Errors);
         }
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
         AV10User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16UserAuthTypeName = "";
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV8LinkURL = "";
         AV12GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
         AV13LastEmailSent = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.sendrecoveryemail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.sendrecoveryemail__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV15UserName ;
      private string AV14IDP_State ;
      private string AV16UserAuthTypeName ;
      private DateTime AV13LastEmailSent ;
      private bool returnInSub ;
      private string AV8LinkURL ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV9Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10User ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserAttribute AV12GAMUserAttribute ;
   }

   public class sendrecoveryemail__gam : DataStoreHelperBase, IDataStoreHelper
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

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class sendrecoveryemail__default : DataStoreHelperBase, IDataStoreHelper
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
