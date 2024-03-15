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
   public class setextendedmenuoptionsvalues : GXProcedure
   {
      public setextendedmenuoptionsvalues( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public setextendedmenuoptionsvalues( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP0_ApplicationMenuOption ,
                           string aP1_ImageUrl ,
                           string aP2_ImageClass ,
                           bool aP3_ShowInExtraSmall ,
                           bool aP4_ShowInSmall ,
                           bool aP5_ShowInMedium ,
                           bool aP6_ShowInLarge )
      {
         this.AV10ApplicationMenuOption = aP0_ApplicationMenuOption;
         this.AV9ImageUrl = aP1_ImageUrl;
         this.AV8ImageClass = aP2_ImageClass;
         this.AV12ShowInExtraSmall = aP3_ShowInExtraSmall;
         this.AV15ShowInSmall = aP4_ShowInSmall;
         this.AV14ShowInMedium = aP5_ShowInMedium;
         this.AV13ShowInLarge = aP6_ShowInLarge;
         initialize();
         executePrivate();
         aP0_ApplicationMenuOption=this.AV10ApplicationMenuOption;
      }

      public void executeSubmit( ref GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP0_ApplicationMenuOption ,
                                 string aP1_ImageUrl ,
                                 string aP2_ImageClass ,
                                 bool aP3_ShowInExtraSmall ,
                                 bool aP4_ShowInSmall ,
                                 bool aP5_ShowInMedium ,
                                 bool aP6_ShowInLarge )
      {
         setextendedmenuoptionsvalues objsetextendedmenuoptionsvalues;
         objsetextendedmenuoptionsvalues = new setextendedmenuoptionsvalues();
         objsetextendedmenuoptionsvalues.AV10ApplicationMenuOption = aP0_ApplicationMenuOption;
         objsetextendedmenuoptionsvalues.AV9ImageUrl = aP1_ImageUrl;
         objsetextendedmenuoptionsvalues.AV8ImageClass = aP2_ImageClass;
         objsetextendedmenuoptionsvalues.AV12ShowInExtraSmall = aP3_ShowInExtraSmall;
         objsetextendedmenuoptionsvalues.AV15ShowInSmall = aP4_ShowInSmall;
         objsetextendedmenuoptionsvalues.AV14ShowInMedium = aP5_ShowInMedium;
         objsetextendedmenuoptionsvalues.AV13ShowInLarge = aP6_ShowInLarge;
         objsetextendedmenuoptionsvalues.context.SetSubmitInitialConfig(context);
         objsetextendedmenuoptionsvalues.initialize();
         Submit( executePrivateCatch,objsetextendedmenuoptionsvalues);
         aP0_ApplicationMenuOption=this.AV10ApplicationMenuOption;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setextendedmenuoptionsvalues)stateInfo).executePrivate();
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
         AV17Properties = AV10ApplicationMenuOption.gxTpr_Properties;
         if ( AV17Properties.Count == 0 )
         {
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV17Properties,  "ImageUrl",  AV9ImageUrl) ;
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV17Properties,  "ImageClass",  AV8ImageClass) ;
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInExtraSmall",  StringUtil.BoolToStr( AV12ShowInExtraSmall)) ;
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInSmall",  StringUtil.BoolToStr( AV15ShowInSmall)) ;
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInMedium",  StringUtil.BoolToStr( AV14ShowInMedium)) ;
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInLarge",  StringUtil.BoolToStr( AV13ShowInLarge)) ;
         }
         else
         {
            new GeneXus.Programs.k2bfsg.setoraddgampropertyvalue(context ).execute( ref  AV17Properties,  "ImageUrl",  AV9ImageUrl) ;
            new GeneXus.Programs.k2bfsg.setoraddgampropertyvalue(context ).execute( ref  AV17Properties,  "ImageClass",  AV8ImageClass) ;
            new GeneXus.Programs.k2bfsg.setoraddgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInExtraSmall",  StringUtil.BoolToStr( AV12ShowInExtraSmall)) ;
            new GeneXus.Programs.k2bfsg.setoraddgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInSmall",  StringUtil.BoolToStr( AV15ShowInSmall)) ;
            new GeneXus.Programs.k2bfsg.setoraddgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInMedium",  StringUtil.BoolToStr( AV14ShowInMedium)) ;
            new GeneXus.Programs.k2bfsg.setoraddgampropertyvalue(context ).execute( ref  AV17Properties,  "ShowInLarge",  StringUtil.BoolToStr( AV13ShowInLarge)) ;
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
         AV17Properties = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty>( context, "GeneXus.Programs.genexussecurity.SdtGAMProperty", "GeneXus.Programs");
         /* GeneXus formulas. */
      }

      private string AV8ImageClass ;
      private bool AV12ShowInExtraSmall ;
      private bool AV15ShowInSmall ;
      private bool AV14ShowInMedium ;
      private bool AV13ShowInLarge ;
      private string AV9ImageUrl ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP0_ApplicationMenuOption ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV17Properties ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV10ApplicationMenuOption ;
   }

}
