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
   public class saveincorrectlogin : GXProcedure
   {
      public saveincorrectlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public saveincorrectlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_LogOnTo ,
                           string aP1_UserName )
      {
         this.AV15LogOnTo = aP0_LogOnTo;
         this.AV17UserName = aP1_UserName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_LogOnTo ,
                                 string aP1_UserName )
      {
         saveincorrectlogin objsaveincorrectlogin;
         objsaveincorrectlogin = new saveincorrectlogin();
         objsaveincorrectlogin.AV15LogOnTo = aP0_LogOnTo;
         objsaveincorrectlogin.AV17UserName = aP1_UserName;
         objsaveincorrectlogin.context.SetSubmitInitialConfig(context);
         objsaveincorrectlogin.initialize();
         Submit( executePrivateCatch,objsaveincorrectlogin);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((saveincorrectlogin)stateInfo).executePrivate();
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
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV15LogOnTo, AV17UserName, out  AV12GetUserErrors);
         if ( AV12GetUserErrors.Count == 0 )
         {
            AV11GAMUserAttribute = AV8GAMUser.getattribute("LoginAttempts", out  AV10Errors);
            if ( AV10Errors.Count == 0 )
            {
               AV14LoginAttempts = (short)(Math.Round(NumberUtil.Val( AV11GAMUserAttribute.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14LoginAttempts = (short)(AV14LoginAttempts+1);
               AV11GAMUserAttribute.gxTpr_Value = StringUtil.Str( (decimal)(AV14LoginAttempts), 4, 0);
               AV8GAMUser.setattribute( AV11GAMUserAttribute, out  AV10Errors);
               /* Execute user subroutine: 'LOGERRORS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else
            {
               AV11GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
               AV11GAMUserAttribute.gxTpr_Id = "LoginAttempts";
               AV11GAMUserAttribute.gxTpr_Value = "1";
               AV11GAMUserAttribute.gxTpr_Ismultivalue = false;
               AV8GAMUser.setattribute( AV11GAMUserAttribute, out  AV10Errors);
               /* Execute user subroutine: 'LOGERRORS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            AV11GAMUserAttribute = AV8GAMUser.getattribute("LastLoginAttempt", out  AV10Errors);
            if ( AV10Errors.Count == 0 )
            {
               AV16Now = DateTimeUtil.ServerNow( context, pr_default);
               AV11GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV16Now, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
               AV8GAMUser.setattribute( AV11GAMUserAttribute, out  AV10Errors);
               /* Execute user subroutine: 'LOGERRORS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else
            {
               AV11GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
               AV11GAMUserAttribute.gxTpr_Id = "LastLoginAttempt";
               AV16Now = DateTimeUtil.ServerNow( context, pr_default);
               AV11GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV16Now, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
               AV11GAMUserAttribute.gxTpr_Ismultivalue = false;
               AV8GAMUser.setattribute( AV11GAMUserAttribute, out  AV10Errors);
               /* Execute user subroutine: 'LOGERRORS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            context.CommitDataStores("k2bfsg.saveincorrectlogin",pr_default);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOGERRORS' Routine */
         returnInSub = false;
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV10Errors.Count )
         {
            AV9Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(AV18GXV1));
            new GeneXus.Core.genexus.common.SdtLog(context).error(AV9Error.tojsonstring()) ;
            AV18GXV1 = (int)(AV18GXV1+1);
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
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV12GetUserErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV16Now = (DateTime)(DateTime.MinValue);
         AV9Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.saveincorrectlogin__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.saveincorrectlogin__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14LoginAttempts ;
      private int AV18GXV1 ;
      private string AV15LogOnTo ;
      private DateTime AV16Now ;
      private bool returnInSub ;
      private string AV17UserName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GetUserErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserAttribute AV11GAMUserAttribute ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV9Error ;
   }

   public class saveincorrectlogin__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class saveincorrectlogin__default : DataStoreHelperBase, IDataStoreHelper
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
