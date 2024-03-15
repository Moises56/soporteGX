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
   public class findgamproperty : GXProcedure
   {
      public findgamproperty( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public findgamproperty( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                           string aP1_Id ,
                           out bool aP2_Found ,
                           out GeneXus.Programs.genexussecurity.SdtGAMProperty aP3_Property )
      {
         this.AV8Properties = aP0_Properties;
         this.AV9Id = aP1_Id;
         this.AV10Found = false ;
         this.AV11Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context) ;
         initialize();
         executePrivate();
         aP2_Found=this.AV10Found;
         aP3_Property=this.AV11Property;
      }

      public GeneXus.Programs.genexussecurity.SdtGAMProperty executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                                                                         string aP1_Id ,
                                                                         out bool aP2_Found )
      {
         execute(aP0_Properties, aP1_Id, out aP2_Found, out aP3_Property);
         return AV11Property ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> aP0_Properties ,
                                 string aP1_Id ,
                                 out bool aP2_Found ,
                                 out GeneXus.Programs.genexussecurity.SdtGAMProperty aP3_Property )
      {
         findgamproperty objfindgamproperty;
         objfindgamproperty = new findgamproperty();
         objfindgamproperty.AV8Properties = aP0_Properties;
         objfindgamproperty.AV9Id = aP1_Id;
         objfindgamproperty.AV10Found = false ;
         objfindgamproperty.AV11Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context) ;
         objfindgamproperty.context.SetSubmitInitialConfig(context);
         objfindgamproperty.initialize();
         Submit( executePrivateCatch,objfindgamproperty);
         aP2_Found=this.AV10Found;
         aP3_Property=this.AV11Property;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((findgamproperty)stateInfo).executePrivate();
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
         AV10Found = false;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV8Properties.Count )
         {
            AV12PropertyIterator = ((GeneXus.Programs.genexussecurity.SdtGAMProperty)AV8Properties.Item(AV13GXV1));
            if ( StringUtil.StrCmp(AV12PropertyIterator.gxTpr_Id, AV9Id) == 0 )
            {
               AV11Property = AV12PropertyIterator;
               AV10Found = true;
               if (true) break;
            }
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV11Property = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV12PropertyIterator = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private string AV9Id ;
      private bool AV10Found ;
      private bool aP2_Found ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty aP3_Property ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV8Properties ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV11Property ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV12PropertyIterator ;
   }

}
