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
namespace GeneXus.Programs {
   public class k2bscjoinstring : GXProcedure
   {
      public k2bscjoinstring( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bscjoinstring( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GxSimpleCollection<string> aP0_CollectionString ,
                           string aP1_Separator ,
                           out string aP2_Result )
      {
         this.AV10CollectionString = aP0_CollectionString;
         this.AV9Separator = aP1_Separator;
         this.AV12Result = "" ;
         initialize();
         executePrivate();
         aP2_Result=this.AV12Result;
      }

      public string executeUdp( GxSimpleCollection<string> aP0_CollectionString ,
                                string aP1_Separator )
      {
         execute(aP0_CollectionString, aP1_Separator, out aP2_Result);
         return AV12Result ;
      }

      public void executeSubmit( GxSimpleCollection<string> aP0_CollectionString ,
                                 string aP1_Separator ,
                                 out string aP2_Result )
      {
         k2bscjoinstring objk2bscjoinstring;
         objk2bscjoinstring = new k2bscjoinstring();
         objk2bscjoinstring.AV10CollectionString = aP0_CollectionString;
         objk2bscjoinstring.AV9Separator = aP1_Separator;
         objk2bscjoinstring.AV12Result = "" ;
         objk2bscjoinstring.context.SetSubmitInitialConfig(context);
         objk2bscjoinstring.initialize();
         Submit( executePrivateCatch,objk2bscjoinstring);
         aP2_Result=this.AV12Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bscjoinstring)stateInfo).executePrivate();
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
         AV8FirstItem = true;
         AV12Result = "";
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV10CollectionString.Count )
         {
            AV11Item = AV10CollectionString.GetString(AV13GXV1);
            if ( AV8FirstItem )
            {
               AV12Result = AV11Item;
               AV8FirstItem = false;
            }
            else
            {
               AV12Result += AV9Separator + AV11Item;
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
         AV12Result = "";
         AV11Item = "";
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private string AV9Separator ;
      private string AV12Result ;
      private string AV11Item ;
      private bool AV8FirstItem ;
      private string aP2_Result ;
      private GxSimpleCollection<string> AV10CollectionString ;
   }

}
