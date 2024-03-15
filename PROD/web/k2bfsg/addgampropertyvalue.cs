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
   public class addgampropertyvalue : GXProcedure
   {
      public addgampropertyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public addgampropertyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                           string aP1_Id ,
                           string aP2_Value )
      {
         this.AV8Properties = aP0_Properties;
         this.AV9Id = aP1_Id;
         this.AV10Value = aP2_Value;
         initialize();
         executePrivate();
         aP0_Properties=this.AV8Properties;
      }

      public void executeSubmit( ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                                 string aP1_Id ,
                                 string aP2_Value )
      {
         addgampropertyvalue objaddgampropertyvalue;
         objaddgampropertyvalue = new addgampropertyvalue();
         objaddgampropertyvalue.AV8Properties = aP0_Properties;
         objaddgampropertyvalue.AV9Id = aP1_Id;
         objaddgampropertyvalue.AV10Value = aP2_Value;
         objaddgampropertyvalue.context.SetSubmitInitialConfig(context);
         objaddgampropertyvalue.initialize();
         Submit( executePrivateCatch,objaddgampropertyvalue);
         aP0_Properties=this.AV8Properties;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((addgampropertyvalue)stateInfo).executePrivate();
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
         AV11Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV11Property.gxTpr_Id = AV9Id;
         AV11Property.gxTpr_Value = AV10Value;
         AV8Properties.Add(AV11Property, 0);
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
         AV11Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         /* GeneXus formulas. */
      }

      private string AV9Id ;
      private string AV10Value ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV8Properties ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV11Property ;
   }

}
