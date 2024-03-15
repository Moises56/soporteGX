using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class gamapplicationmenutok2bmultilevelmenu : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public gamapplicationmenutok2bmultilevelmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gamapplicationmenutok2bmultilevelmenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> aP0_GAMMenuOptionList ,
                           out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP1_Gxm2rootcol )
      {
         this.AV8GAMMenuOptionList = aP0_GAMMenuOptionList;
         this.Gxm2rootcol = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> aP0_GAMMenuOptionList )
      {
         execute(aP0_GAMMenuOptionList, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> aP0_GAMMenuOptionList ,
                                 out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP1_Gxm2rootcol )
      {
         gamapplicationmenutok2bmultilevelmenu objgamapplicationmenutok2bmultilevelmenu;
         objgamapplicationmenutok2bmultilevelmenu = new gamapplicationmenutok2bmultilevelmenu();
         objgamapplicationmenutok2bmultilevelmenu.AV8GAMMenuOptionList = aP0_GAMMenuOptionList;
         objgamapplicationmenutok2bmultilevelmenu.Gxm2rootcol = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         objgamapplicationmenutok2bmultilevelmenu.context.SetSubmitInitialConfig(context);
         objgamapplicationmenutok2bmultilevelmenu.initialize();
         Submit( executePrivateCatch,objgamapplicationmenutok2bmultilevelmenu);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamapplicationmenutok2bmultilevelmenu)stateInfo).executePrivate();
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
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV8GAMMenuOptionList.Count )
         {
            AV11MenuItem = ((GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList)AV8GAMMenuOptionList.Item(AV19GXV1));
            Gxm1k2bmultilevelmenu = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
            Gxm2rootcol.Add(Gxm1k2bmultilevelmenu, 0);
            GXt_boolean1 = false;
            new GeneXus.Programs.k2bfsg.getextendedmenuoptionsvalues(context ).execute(  AV11MenuItem.gxTpr_Properties, out  AV10ImageUrl, out  AV9ImageClass, out  AV12ShowInExtraSmall, out  AV15ShowInSmall, out  AV14ShowInMedium, out  GXt_boolean1) ;
            Gxm1k2bmultilevelmenu.gxTpr_Showinlarge = GXt_boolean1;
            Gxm1k2bmultilevelmenu.gxTpr_Code = AV11MenuItem.gxTpr_Name;
            Gxm1k2bmultilevelmenu.gxTpr_Title = AV11MenuItem.gxTpr_Description;
            Gxm1k2bmultilevelmenu.gxTpr_Imageurl = AV10ImageUrl;
            Gxm1k2bmultilevelmenu.gxTpr_Imageclass = AV9ImageClass;
            Gxm1k2bmultilevelmenu.gxTpr_Link = AV11MenuItem.gxTpr_Link;
            GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>();
            new GeneXus.Programs.k2bfsg.gamapplicationmenutok2bmultilevelmenu(context ).execute(  AV11MenuItem.gxTpr_Nodes, out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2) ;
            Gxm1k2bmultilevelmenu.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2;
            Gxm1k2bmultilevelmenu.gxTpr_Showinextrasmall = AV12ShowInExtraSmall;
            Gxm1k2bmultilevelmenu.gxTpr_Showinsmall = AV15ShowInSmall;
            Gxm1k2bmultilevelmenu.gxTpr_Showinmedium = AV14ShowInMedium;
            AV19GXV1 = (int)(AV19GXV1+1);
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
         AV11MenuItem = new GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList(context);
         Gxm1k2bmultilevelmenu = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV10ImageUrl = "";
         AV9ImageClass = "";
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private string AV9ImageClass ;
      private bool GXt_boolean1 ;
      private bool AV12ShowInExtraSmall ;
      private bool AV15ShowInSmall ;
      private bool AV14ShowInMedium ;
      private string AV10ImageUrl ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP1_Gxm2rootcol ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> AV8GAMMenuOptionList ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> Gxm2rootcol ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList AV11MenuItem ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem Gxm1k2bmultilevelmenu ;
   }

}
