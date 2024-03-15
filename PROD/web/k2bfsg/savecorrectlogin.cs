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
   public class savecorrectlogin : GXProcedure
   {
      public savecorrectlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public savecorrectlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_LogOnTo ,
                           string aP1_UserName )
      {
         this.AV14LogOnTo = aP0_LogOnTo;
         this.AV15UserName = aP1_UserName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_LogOnTo ,
                                 string aP1_UserName )
      {
         savecorrectlogin objsavecorrectlogin;
         objsavecorrectlogin = new savecorrectlogin();
         objsavecorrectlogin.AV14LogOnTo = aP0_LogOnTo;
         objsavecorrectlogin.AV15UserName = aP1_UserName;
         objsavecorrectlogin.context.SetSubmitInitialConfig(context);
         objsavecorrectlogin.initialize();
         Submit( executePrivateCatch,objsavecorrectlogin);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((savecorrectlogin)stateInfo).executePrivate();
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
         AV12GAMUserAux = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV14LogOnTo, AV15UserName, out  AV13GetUserErrors);
         if ( AV13GetUserErrors.Count == 0 )
         {
            AV11GAMUserAttribute = AV12GAMUserAux.getattribute("LoginAttempts", out  AV10Errors);
            if ( AV10Errors.Count == 0 )
            {
               AV11GAMUserAttribute.gxTpr_Value = "0";
               AV12GAMUserAux.setattribute( AV11GAMUserAttribute, out  AV10Errors);
            }
            else
            {
               AV11GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
               AV11GAMUserAttribute.gxTpr_Id = "LoginAttempts";
               AV11GAMUserAttribute.gxTpr_Value = "0";
               AV11GAMUserAttribute.gxTpr_Ismultivalue = false;
               AV12GAMUserAux.setattribute( AV11GAMUserAttribute, out  AV10Errors);
            }
            AV11GAMUserAttribute = AV12GAMUserAux.getattribute("LastLoginAttempt", out  AV10Errors);
            if ( AV10Errors.Count == 0 )
            {
               AV17Now = DateTimeUtil.ServerNow( context, pr_default);
               AV11GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV17Now, 8, 5, 1, 2, "/", ":", " ");
               AV12GAMUserAux.setattribute( AV11GAMUserAttribute, out  AV10Errors);
            }
            else
            {
               AV11GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
               AV11GAMUserAttribute.gxTpr_Id = "LastLoginAttempt";
               AV17Now = DateTimeUtil.ServerNow( context, pr_default);
               AV11GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV17Now, 8, 5, 1, 2, "/", ":", " ");
               AV11GAMUserAttribute.gxTpr_Ismultivalue = false;
               AV12GAMUserAux.setattribute( AV11GAMUserAttribute, out  AV10Errors);
            }
            context.CommitDataStores("k2bfsg.savecorrectlogin",pr_default);
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
         AV12GAMUserAux = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV13GetUserErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV17Now = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.savecorrectlogin__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.savecorrectlogin__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV14LogOnTo ;
      private DateTime AV17Now ;
      private string AV15UserName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13GetUserErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUserAux ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserAttribute AV11GAMUserAttribute ;
   }

   public class savecorrectlogin__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class savecorrectlogin__default : DataStoreHelperBase, IDataStoreHelper
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
