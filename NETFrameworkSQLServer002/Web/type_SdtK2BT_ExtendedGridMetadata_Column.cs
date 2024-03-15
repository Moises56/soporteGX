/*
				   File: type_SdtK2BT_ExtendedGridMetadata_Column
			Description: Columns
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
	[XmlRoot(ElementName="K2BT_ExtendedGridMetadata.Column")]
	[XmlType(TypeName="K2BT_ExtendedGridMetadata.Column" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_ExtendedGridMetadata_Column : GxUserType
	{
		public SdtK2BT_ExtendedGridMetadata_Column( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Name = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Filtersectioninternalname = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationcaption = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationvalue = "";

		}

		public SdtK2BT_ExtendedGridMetadata_Column(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("FilterSectionInternalName", gxTpr_Filtersectioninternalname, false);


			AddObjectProperty("ContainsActiveFilter", gxTpr_Containsactivefilter, false);


			AddObjectProperty("AscendingOrder", gxTpr_Ascendingorder, false);


			AddObjectProperty("DescendingOrder", gxTpr_Descendingorder, false);


			AddObjectProperty("HasAggregation", gxTpr_Hasaggregation, false);


			AddObjectProperty("AggregationCaption", gxTpr_Aggregationcaption, false);


			AddObjectProperty("AggregationValue", gxTpr_Aggregationvalue, false);

			if (gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations != null)
			{
				AddObjectProperty("Aggregations", gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Name; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="FilterSectionInternalName")]
		[XmlElement(ElementName="FilterSectionInternalName")]
		public string gxTpr_Filtersectioninternalname
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Filtersectioninternalname; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Filtersectioninternalname = value;
				SetDirty("Filtersectioninternalname");
			}
		}




		[SoapElement(ElementName="ContainsActiveFilter")]
		[XmlElement(ElementName="ContainsActiveFilter")]
		public bool gxTpr_Containsactivefilter
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Containsactivefilter; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Containsactivefilter = value;
				SetDirty("Containsactivefilter");
			}
		}




		[SoapElement(ElementName="AscendingOrder")]
		[XmlElement(ElementName="AscendingOrder")]
		public short gxTpr_Ascendingorder
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Ascendingorder; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Ascendingorder = value;
				SetDirty("Ascendingorder");
			}
		}




		[SoapElement(ElementName="DescendingOrder")]
		[XmlElement(ElementName="DescendingOrder")]
		public short gxTpr_Descendingorder
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Descendingorder; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Descendingorder = value;
				SetDirty("Descendingorder");
			}
		}




		[SoapElement(ElementName="HasAggregation")]
		[XmlElement(ElementName="HasAggregation")]
		public bool gxTpr_Hasaggregation
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Hasaggregation; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Hasaggregation = value;
				SetDirty("Hasaggregation");
			}
		}




		[SoapElement(ElementName="AggregationCaption")]
		[XmlElement(ElementName="AggregationCaption")]
		public string gxTpr_Aggregationcaption
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationcaption; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationcaption = value;
				SetDirty("Aggregationcaption");
			}
		}




		[SoapElement(ElementName="AggregationValue")]
		[XmlElement(ElementName="AggregationValue")]
		public string gxTpr_Aggregationvalue
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationvalue; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationvalue = value;
				SetDirty("Aggregationvalue");
			}
		}




		[SoapElement(ElementName="Aggregations" )]
		[XmlArray(ElementName="Aggregations"  )]
		[XmlArrayItemAttribute(ElementName="Aggregation" , IsNullable=false )]
		public GXBaseCollection<SdtK2BT_ExtendedGridMetadata_Column_Aggregation> gxTpr_Aggregations
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations = new GXBaseCollection<SdtK2BT_ExtendedGridMetadata_Column_Aggregation>( context, "K2BT_ExtendedGridMetadata.Column.Aggregation", "");
				}
				return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations = value;
				SetDirty("Aggregations");
			}
		}

		public void gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations_SetNull()
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations_N = true;
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations = null;
		}

		public bool gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations == null;
		}
		public bool ShouldSerializegxTpr_Aggregations_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations != null && gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Name = "";
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Filtersectioninternalname = "";




			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationcaption = "";
			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationvalue = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Column_Name;
		 

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Column_Filtersectioninternalname;
		 

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_Column_Containsactivefilter;
		 

		protected short gxTv_SdtK2BT_ExtendedGridMetadata_Column_Ascendingorder;
		 

		protected short gxTv_SdtK2BT_ExtendedGridMetadata_Column_Descendingorder;
		 

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_Column_Hasaggregation;
		 

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationcaption;
		 

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregationvalue;
		 
		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations_N;
		protected GXBaseCollection<SdtK2BT_ExtendedGridMetadata_Column_Aggregation> gxTv_SdtK2BT_ExtendedGridMetadata_Column_Aggregations = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BT_ExtendedGridMetadata.Column", Namespace="test")]
	public class SdtK2BT_ExtendedGridMetadata_Column_RESTInterface : GxGenericCollectionItem<SdtK2BT_ExtendedGridMetadata_Column>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_ExtendedGridMetadata_Column_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_ExtendedGridMetadata_Column_RESTInterface( SdtK2BT_ExtendedGridMetadata_Column psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="FilterSectionInternalName", Order=1)]
		public  string gxTpr_Filtersectioninternalname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Filtersectioninternalname);

			}
			set { 
				 sdt.gxTpr_Filtersectioninternalname = value;
			}
		}

		[DataMember(Name="ContainsActiveFilter", Order=2)]
		public bool gxTpr_Containsactivefilter
		{
			get { 
				return sdt.gxTpr_Containsactivefilter;

			}
			set { 
				sdt.gxTpr_Containsactivefilter = value;
			}
		}

		[DataMember(Name="AscendingOrder", Order=3)]
		public short gxTpr_Ascendingorder
		{
			get { 
				return sdt.gxTpr_Ascendingorder;

			}
			set { 
				sdt.gxTpr_Ascendingorder = value;
			}
		}

		[DataMember(Name="DescendingOrder", Order=4)]
		public short gxTpr_Descendingorder
		{
			get { 
				return sdt.gxTpr_Descendingorder;

			}
			set { 
				sdt.gxTpr_Descendingorder = value;
			}
		}

		[DataMember(Name="HasAggregation", Order=5)]
		public bool gxTpr_Hasaggregation
		{
			get { 
				return sdt.gxTpr_Hasaggregation;

			}
			set { 
				sdt.gxTpr_Hasaggregation = value;
			}
		}

		[DataMember(Name="AggregationCaption", Order=6)]
		public  string gxTpr_Aggregationcaption
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Aggregationcaption);

			}
			set { 
				 sdt.gxTpr_Aggregationcaption = value;
			}
		}

		[DataMember(Name="AggregationValue", Order=7)]
		public  string gxTpr_Aggregationvalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Aggregationvalue);

			}
			set { 
				 sdt.gxTpr_Aggregationvalue = value;
			}
		}

		[DataMember(Name="Aggregations", Order=8, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BT_ExtendedGridMetadata_Column_Aggregation_RESTInterface> gxTpr_Aggregations
		{
			get {
				if (sdt.ShouldSerializegxTpr_Aggregations_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BT_ExtendedGridMetadata_Column_Aggregation_RESTInterface>(sdt.gxTpr_Aggregations);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Aggregations);
			}
		}


		#endregion

		public SdtK2BT_ExtendedGridMetadata_Column sdt
		{
			get { 
				return (SdtK2BT_ExtendedGridMetadata_Column)Sdt;
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
				sdt = new SdtK2BT_ExtendedGridMetadata_Column() ;
			}
		}
	}
	#endregion
}