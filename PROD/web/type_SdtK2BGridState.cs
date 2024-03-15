/*
				   File: type_SdtK2BGridState
			Description: K2BGridState
				 Author: Nemo 🐠 for C# version 18.0.5.175581
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="K2BGridState")]
	[XmlType(TypeName="K2BGridState" , Namespace="test" )]
	[Serializable]
	public class SdtK2BGridState : GxUserType
	{
		public SdtK2BGridState( )
		{
			/* Constructor for serialization */
		}

		public SdtK2BGridState(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("CurrentPage", gxTpr_Currentpage, false);


			AddObjectProperty("RowsPerPage", gxTpr_Rowsperpage, false);


			AddObjectProperty("OrderedBy", gxTpr_Orderedby, false);

			if (gxTv_SdtK2BGridState_Filtervalues != null)
			{
				AddObjectProperty("FilterValues", gxTv_SdtK2BGridState_Filtervalues, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CurrentPage")]
		[XmlElement(ElementName="CurrentPage")]
		public short gxTpr_Currentpage
		{
			get {
				return gxTv_SdtK2BGridState_Currentpage; 
			}
			set {
				gxTv_SdtK2BGridState_Currentpage = value;
				SetDirty("Currentpage");
			}
		}




		[SoapElement(ElementName="RowsPerPage")]
		[XmlElement(ElementName="RowsPerPage")]
		public short gxTpr_Rowsperpage
		{
			get {
				return gxTv_SdtK2BGridState_Rowsperpage; 
			}
			set {
				gxTv_SdtK2BGridState_Rowsperpage = value;
				SetDirty("Rowsperpage");
			}
		}




		[SoapElement(ElementName="OrderedBy")]
		[XmlElement(ElementName="OrderedBy")]
		public short gxTpr_Orderedby
		{
			get {
				return gxTv_SdtK2BGridState_Orderedby; 
			}
			set {
				gxTv_SdtK2BGridState_Orderedby = value;
				SetDirty("Orderedby");
			}
		}




		[SoapElement(ElementName="FilterValues" )]
		[XmlArray(ElementName="FilterValues"  )]
		[XmlArrayItemAttribute(ElementName="FilterValue" , IsNullable=false )]
		public GXBaseCollection<SdtK2BGridState_FilterValue> gxTpr_Filtervalues
		{
			get {
				if ( gxTv_SdtK2BGridState_Filtervalues == null )
				{
					gxTv_SdtK2BGridState_Filtervalues = new GXBaseCollection<SdtK2BGridState_FilterValue>( context, "K2BGridState.FilterValue", "");
				}
				return gxTv_SdtK2BGridState_Filtervalues;
			}
			set {
				gxTv_SdtK2BGridState_Filtervalues_N = false;
				gxTv_SdtK2BGridState_Filtervalues = value;
				SetDirty("Filtervalues");
			}
		}

		public void gxTv_SdtK2BGridState_Filtervalues_SetNull()
		{
			gxTv_SdtK2BGridState_Filtervalues_N = true;
			gxTv_SdtK2BGridState_Filtervalues = null;
		}

		public bool gxTv_SdtK2BGridState_Filtervalues_IsNull()
		{
			return gxTv_SdtK2BGridState_Filtervalues == null;
		}
		public bool ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BGridState_Filtervalues != null && gxTv_SdtK2BGridState_Filtervalues.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BGridState_Filtervalues_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtK2BGridState_Currentpage;
		 

		protected short gxTv_SdtK2BGridState_Rowsperpage;
		 

		protected short gxTv_SdtK2BGridState_Orderedby;
		 
		protected bool gxTv_SdtK2BGridState_Filtervalues_N;
		protected GXBaseCollection<SdtK2BGridState_FilterValue> gxTv_SdtK2BGridState_Filtervalues = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BGridState", Namespace="test")]
	public class SdtK2BGridState_RESTInterface : GxGenericCollectionItem<SdtK2BGridState>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BGridState_RESTInterface( ) : base()
		{	
		}

		public SdtK2BGridState_RESTInterface( SdtK2BGridState psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CurrentPage", Order=0)]
		public short gxTpr_Currentpage
		{
			get { 
				return sdt.gxTpr_Currentpage;

			}
			set { 
				sdt.gxTpr_Currentpage = value;
			}
		}

		[DataMember(Name="RowsPerPage", Order=1)]
		public short gxTpr_Rowsperpage
		{
			get { 
				return sdt.gxTpr_Rowsperpage;

			}
			set { 
				sdt.gxTpr_Rowsperpage = value;
			}
		}

		[DataMember(Name="OrderedBy", Order=2)]
		public short gxTpr_Orderedby
		{
			get { 
				return sdt.gxTpr_Orderedby;

			}
			set { 
				sdt.gxTpr_Orderedby = value;
			}
		}

		[DataMember(Name="FilterValues", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BGridState_FilterValue_RESTInterface> gxTpr_Filtervalues
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BGridState_FilterValue_RESTInterface>(sdt.gxTpr_Filtervalues);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Filtervalues);
			}
		}


		#endregion

		public SdtK2BGridState sdt
		{
			get { 
				return (SdtK2BGridState)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtK2BGridState() ;
			}
		}
	}
	#endregion
}