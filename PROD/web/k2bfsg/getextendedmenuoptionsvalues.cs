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
   public class getextendedmenuoptionsvalues : GXProcedure
   {
      public getextendedmenuoptionsvalues( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getextendedmenuoptionsvalues( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                           out string aP1_ImageUrl ,
                           out string aP2_ImageClass ,
                           out bool aP3_ShowInExtraSmall ,
                           out bool aP4_ShowInSmall ,
                           out bool aP5_ShowInMedium ,
                           out bool aP6_ShowInLarge )
      {
         this.AV14Properties = aP0_Properties;
         this.AV8ImageUrl = "" ;
         this.AV9ImageClass = "" ;
         this.AV10ShowInExtraSmall = false ;
         this.AV11ShowInSmall = false ;
         this.AV12ShowInMedium = false ;
         this.AV13ShowInLarge = false ;
         initialize();
         executePrivate();
         aP1_ImageUrl=this.AV8ImageUrl;
         aP2_ImageClass=this.AV9ImageClass;
         aP3_ShowInExtraSmall=this.AV10ShowInExtraSmall;
         aP4_ShowInSmall=this.AV11ShowInSmall;
         aP5_ShowInMedium=this.AV12ShowInMedium;
         aP6_ShowInLarge=this.AV13ShowInLarge;
      }

      public bool executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                              out string aP1_ImageUrl ,
                              out string aP2_ImageClass ,
                              out bool aP3_ShowInExtraSmall ,
                              out bool aP4_ShowInSmall ,
                              out bool aP5_ShowInMedium )
      {
         execute(aP0_Properties, out aP1_ImageUrl, out aP2_ImageClass, out aP3_ShowInExtraSmall, out aP4_ShowInSmall, out aP5_ShowInMedium, out aP6_ShowInLarge);
         return AV13ShowInLarge ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                                 out string aP1_ImageUrl ,
                                 out string aP2_ImageClass ,
                                 out bool aP3_ShowInExtraSmall ,
                                 out bool aP4_ShowInSmall ,
                                 out bool aP5_ShowInMedium ,
                                 out bool aP6_ShowInLarge )
      {
         getextendedmenuoptionsvalues objgetextendedmenuoptionsvalues;
         objgetextendedmenuoptionsvalues = new getextendedmenuoptionsvalues();
         objgetextendedmenuoptionsvalues.AV14Properties = aP0_Properties;
         objgetextendedmenuoptionsvalues.AV8ImageUrl = "" ;
         objgetextendedmenuoptionsvalues.AV9ImageClass = "" ;
         objgetextendedmenuoptionsvalues.AV10ShowInExtraSmall = false ;
         objgetextendedmenuoptionsvalues.AV11ShowInSmall = false ;
         objgetextendedmenuoptionsvalues.AV12ShowInMedium = false ;
         objgetextendedmenuoptionsvalues.AV13ShowInLarge = false ;
         objgetextendedmenuoptionsvalues.context.SetSubmitInitialConfig(context);
         objgetextendedmenuoptionsvalues.initialize();
         Submit( executePrivateCatch,objgetextendedmenuoptionsvalues);
         aP1_ImageUrl=this.AV8ImageUrl;
         aP2_ImageClass=this.AV9ImageClass;
         aP3_ShowInExtraSmall=this.AV10ShowInExtraSmall;
         aP4_ShowInSmall=this.AV11ShowInSmall;
         aP5_ShowInMedium=this.AV12ShowInMedium;
         aP6_ShowInLarge=this.AV13ShowInLarge;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getextendedmenuoptionsvalues)stateInfo).executePrivate();
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
         AV10ShowInExtraSmall = true;
         AV11ShowInSmall = true;
         AV12ShowInMedium = true;
         AV13ShowInLarge = true;
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV14Properties.Count )
         {
            AV15Property = ((GeneXus.Programs.genexussecurity.SdtGAMProperty)AV14Properties.Item(AV16GXV1));
            if ( StringUtil.StrCmp(AV15Property.gxTpr_Id, "ImageUrl") == 0 )
            {
               AV8ImageUrl = AV15Property.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV15Property.gxTpr_Id, "ImageClass") == 0 )
            {
               AV9ImageClass = AV15Property.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV15Property.gxTpr_Id, "ShowInExtraSmall") == 0 )
            {
               AV10ShowInExtraSmall = BooleanUtil.Val( AV15Property.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV15Property.gxTpr_Id, "ShowInSmall") == 0 )
            {
               AV11ShowInSmall = BooleanUtil.Val( AV15Property.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV15Property.gxTpr_Id, "ShowInMedium") == 0 )
            {
               AV12ShowInMedium = BooleanUtil.Val( AV15Property.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV15Property.gxTpr_Id, "ShowInLarge") == 0 )
            {
               AV13ShowInLarge = BooleanUtil.Val( AV15Property.gxTpr_Value);
            }
            AV16GXV1 = (int)(AV16GXV1+1);
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
         AV8ImageUrl = "";
         AV9ImageClass = "";
         AV15Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         /* GeneXus formulas. */
      }

      private int AV16GXV1 ;
      private string AV9ImageClass ;
      private bool AV10ShowInExtraSmall ;
      private bool AV11ShowInSmall ;
      private bool AV12ShowInMedium ;
      private bool AV13ShowInLarge ;
      private string AV8ImageUrl ;
      private string aP1_ImageUrl ;
      private string aP2_ImageClass ;
      private bool aP3_ShowInExtraSmall ;
      private bool aP4_ShowInSmall ;
      private bool aP5_ShowInMedium ;
      private bool aP6_ShowInLarge ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV14Properties ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV15Property ;
   }

}
