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
   public class setoraddgampropertyvalue : GXProcedure
   {
      public setoraddgampropertyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public setoraddgampropertyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                           string aP1_Id ,
                           string aP2_Value )
      {
         this.AV8Properties = aP0_Properties;
         this.AV10Id = aP1_Id;
         this.AV11Value = aP2_Value;
         initialize();
         executePrivate();
         aP0_Properties=this.AV8Properties;
      }

      public void executeSubmit( ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                                 string aP1_Id ,
                                 string aP2_Value )
      {
         setoraddgampropertyvalue objsetoraddgampropertyvalue;
         objsetoraddgampropertyvalue = new setoraddgampropertyvalue();
         objsetoraddgampropertyvalue.AV8Properties = aP0_Properties;
         objsetoraddgampropertyvalue.AV10Id = aP1_Id;
         objsetoraddgampropertyvalue.AV11Value = aP2_Value;
         objsetoraddgampropertyvalue.context.SetSubmitInitialConfig(context);
         objsetoraddgampropertyvalue.initialize();
         Submit( executePrivateCatch,objsetoraddgampropertyvalue);
         aP0_Properties=this.AV8Properties;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setoraddgampropertyvalue)stateInfo).executePrivate();
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
         new GeneXus.Programs.k2bfsg.findgamproperty(context ).execute(  AV8Properties,  AV10Id, out  AV12HasProperty, out  AV9Property) ;
         if ( AV12HasProperty )
         {
            AV9Property.gxTpr_Value = AV11Value;
         }
         else
         {
            new GeneXus.Programs.k2bfsg.addgampropertyvalue(context ).execute( ref  AV8Properties,  AV10Id,  AV11Value) ;
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
         AV9Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         /* GeneXus formulas. */
      }

      private string AV10Id ;
      private bool AV12HasProperty ;
      private string AV11Value ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV8Properties ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV9Property ;
   }

}
