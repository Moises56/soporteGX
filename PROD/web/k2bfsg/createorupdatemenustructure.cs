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
   public class createorupdatemenustructure : GXProcedure
   {
      public createorupdatemenustructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public createorupdatemenustructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ApplicationId ,
                           string aP1_Code ,
                           GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP2_Menu ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ,
                           out long aP4_MenuId ,
                           out bool aP5_newMenu ,
                           out bool aP6_Result )
      {
         this.AV9ApplicationId = aP0_ApplicationId;
         this.AV11Code = aP1_Code;
         this.AV16Menu = aP2_Menu;
         this.AV13Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV18MenuId = 0 ;
         this.AV19newMenu = false ;
         this.AV20Result = false ;
         initialize();
         executePrivate();
         aP3_Errors=this.AV13Errors;
         aP4_MenuId=this.AV18MenuId;
         aP5_newMenu=this.AV19newMenu;
         aP6_Result=this.AV20Result;
      }

      public bool executeUdp( long aP0_ApplicationId ,
                              string aP1_Code ,
                              GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP2_Menu ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ,
                              out long aP4_MenuId ,
                              out bool aP5_newMenu )
      {
         execute(aP0_ApplicationId, aP1_Code, aP2_Menu, out aP3_Errors, out aP4_MenuId, out aP5_newMenu, out aP6_Result);
         return AV20Result ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 string aP1_Code ,
                                 GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP2_Menu ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ,
                                 out long aP4_MenuId ,
                                 out bool aP5_newMenu ,
                                 out bool aP6_Result )
      {
         createorupdatemenustructure objcreateorupdatemenustructure;
         objcreateorupdatemenustructure = new createorupdatemenustructure();
         objcreateorupdatemenustructure.AV9ApplicationId = aP0_ApplicationId;
         objcreateorupdatemenustructure.AV11Code = aP1_Code;
         objcreateorupdatemenustructure.AV16Menu = aP2_Menu;
         objcreateorupdatemenustructure.AV13Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objcreateorupdatemenustructure.AV18MenuId = 0 ;
         objcreateorupdatemenustructure.AV19newMenu = false ;
         objcreateorupdatemenustructure.AV20Result = false ;
         objcreateorupdatemenustructure.context.SetSubmitInitialConfig(context);
         objcreateorupdatemenustructure.initialize();
         Submit( executePrivateCatch,objcreateorupdatemenustructure);
         aP3_Errors=this.AV13Errors;
         aP4_MenuId=this.AV18MenuId;
         aP5_newMenu=this.AV19newMenu;
         aP6_Result=this.AV20Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createorupdatemenustructure)stateInfo).executePrivate();
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
         AV8Application.load( AV9ApplicationId);
         GXt_SdtGAMApplicationMenu1 = AV10ApplicationMenu;
         new GeneXus.Programs.k2bfsg.getmenubyname(context ).execute(  AV8Application,  AV11Code, out  GXt_SdtGAMApplicationMenu1) ;
         AV10ApplicationMenu = GXt_SdtGAMApplicationMenu1;
         if ( (0==AV10ApplicationMenu.gxTpr_Id) )
         {
            AV10ApplicationMenu.gxTpr_Name = AV11Code;
            AV10ApplicationMenu.gxTpr_Description = AV11Code;
            AV15IsOK = AV8Application.addmenu(AV10ApplicationMenu, out  AV14GAMErrors);
            AV19newMenu = true;
            if ( AV15IsOK )
            {
               AV20Result = true;
               context.CommitDataStores("k2bfsg.createorupdatemenustructure",pr_default);
               GXt_SdtGAMApplicationMenu1 = AV10ApplicationMenu;
               new GeneXus.Programs.k2bfsg.getmenubyname(context ).execute(  AV8Application,  AV11Code, out  GXt_SdtGAMApplicationMenu1) ;
               AV10ApplicationMenu = GXt_SdtGAMApplicationMenu1;
            }
            else
            {
               AV20Result = false;
               GXt_objcol_SdtMessages_Message2 = AV13Errors;
               new GeneXus.Programs.k2bfsg.convertgammessagestomessages(context ).execute(  AV14GAMErrors, out  GXt_objcol_SdtMessages_Message2) ;
               AV13Errors = GXt_objcol_SdtMessages_Message2;
            }
         }
         else
         {
            AV19newMenu = false;
            AV10ApplicationMenu.gxTpr_Name = AV11Code;
            AV10ApplicationMenu.gxTpr_Description = AV11Code;
            AV15IsOK = AV8Application.updatemenu(AV10ApplicationMenu, out  AV14GAMErrors);
            if ( AV15IsOK )
            {
               AV20Result = true;
               context.CommitDataStores("k2bfsg.createorupdatemenustructure",pr_default);
            }
            else
            {
               AV20Result = false;
               GXt_objcol_SdtMessages_Message2 = AV13Errors;
               new GeneXus.Programs.k2bfsg.convertgammessagestomessages(context ).execute(  AV14GAMErrors, out  GXt_objcol_SdtMessages_Message2) ;
               AV13Errors = GXt_objcol_SdtMessages_Message2;
            }
         }
         if ( AV20Result )
         {
            GXt_boolean3 = AV20Result;
            new GeneXus.Programs.k2bfsg.addmenuoptions(context ).execute(  AV16Menu,  AV8Application,  AV10ApplicationMenu, ref  AV13Errors, ref  GXt_boolean3) ;
            AV20Result = GXt_boolean3;
            AV18MenuId = AV10ApplicationMenu.gxTpr_Id;
            context.CommitDataStores("k2bfsg.createorupdatemenustructure",pr_default);
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
         AV13Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV10ApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV14GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtGAMApplicationMenu1 = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         GXt_objcol_SdtMessages_Message2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.createorupdatemenustructure__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.createorupdatemenustructure__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9ApplicationId ;
      private long AV18MenuId ;
      private string AV11Code ;
      private bool AV19newMenu ;
      private bool AV20Result ;
      private bool AV15IsOK ;
      private bool GXt_boolean3 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ;
      private long aP4_MenuId ;
      private bool aP5_newMenu ;
      private bool aP6_Result ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message2 ;
      private GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> AV16Menu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV10ApplicationMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu GXt_SdtGAMApplicationMenu1 ;
   }

   public class createorupdatemenustructure__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class createorupdatemenustructure__default : DataStoreHelperBase, IDataStoreHelper
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
