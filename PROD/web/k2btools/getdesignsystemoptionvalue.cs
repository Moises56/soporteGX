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
namespace GeneXus.Programs.k2btools {
   public class getdesignsystemoptionvalue : GXProcedure
   {
      public getdesignsystemoptionvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getdesignsystemoptionvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_OptionName ,
                           out string aP1_OptionValue )
      {
         this.AV8OptionName = aP0_OptionName;
         this.AV9OptionValue = "" ;
         initialize();
         executePrivate();
         aP1_OptionValue=this.AV9OptionValue;
      }

      public string executeUdp( string aP0_OptionName )
      {
         execute(aP0_OptionName, out aP1_OptionValue);
         return AV9OptionValue ;
      }

      public void executeSubmit( string aP0_OptionName ,
                                 out string aP1_OptionValue )
      {
         getdesignsystemoptionvalue objgetdesignsystemoptionvalue;
         objgetdesignsystemoptionvalue = new getdesignsystemoptionvalue();
         objgetdesignsystemoptionvalue.AV8OptionName = aP0_OptionName;
         objgetdesignsystemoptionvalue.AV9OptionValue = "" ;
         objgetdesignsystemoptionvalue.context.SetSubmitInitialConfig(context);
         objgetdesignsystemoptionvalue.initialize();
         Submit( executePrivateCatch,objgetdesignsystemoptionvalue);
         aP1_OptionValue=this.AV9OptionValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getdesignsystemoptionvalue)stateInfo).executePrivate();
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
         AV9OptionValue = "";
         AV12GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV11GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV11GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV10Option = ((SdtK2BAttributeValue_Item)AV11GXV1.Item(AV12GXV2));
            if ( StringUtil.StrCmp(AV10Option.gxTpr_Attributename, AV8OptionName) == 0 )
            {
               AV9OptionValue = AV10Option.gxTpr_Attributevalue;
               this.cleanup();
               if (true) return;
            }
            AV12GXV2 = (int)(AV12GXV2+1);
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
         AV9OptionValue = "";
         AV11GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV10Option = new SdtK2BAttributeValue_Item(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV2 ;
      private string AV8OptionName ;
      private string AV9OptionValue ;
      private string aP1_OptionValue ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV11GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private SdtK2BAttributeValue_Item AV10Option ;
   }

}
