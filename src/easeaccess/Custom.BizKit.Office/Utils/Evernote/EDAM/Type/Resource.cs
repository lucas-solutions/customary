/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Custom.Utils.Evernote.EDAM.Type
{

  #if !SILVERLIGHT && !NETFX_CORE
  [Serializable]
  #endif
  public partial class Resource : TBase
  {
    private string _guid;
    private string _noteGuid;
    private Data _data;
    private string _mime;
    private short _width;
    private short _height;
    private short _duration;
    private bool _active;
    private Data _recognition;
    private ResourceAttributes _attributes;
    private int _updateSequenceNum;
    private Data _alternateData;

    public string Guid
    {
      get
      {
        return _guid;
      }
      set
      {
        __isset.guid = true;
        this._guid = value;
      }
    }

    public string NoteGuid
    {
      get
      {
        return _noteGuid;
      }
      set
      {
        __isset.noteGuid = true;
        this._noteGuid = value;
      }
    }

    public Data Data
    {
      get
      {
        return _data;
      }
      set
      {
        __isset.data = true;
        this._data = value;
      }
    }

    public string Mime
    {
      get
      {
        return _mime;
      }
      set
      {
        __isset.mime = true;
        this._mime = value;
      }
    }

    public short Width
    {
      get
      {
        return _width;
      }
      set
      {
        __isset.width = true;
        this._width = value;
      }
    }

    public short Height
    {
      get
      {
        return _height;
      }
      set
      {
        __isset.height = true;
        this._height = value;
      }
    }

    public short Duration
    {
      get
      {
        return _duration;
      }
      set
      {
        __isset.duration = true;
        this._duration = value;
      }
    }

    public bool Active
    {
      get
      {
        return _active;
      }
      set
      {
        __isset.active = true;
        this._active = value;
      }
    }

    public Data Recognition
    {
      get
      {
        return _recognition;
      }
      set
      {
        __isset.recognition = true;
        this._recognition = value;
      }
    }

    public ResourceAttributes Attributes
    {
      get
      {
        return _attributes;
      }
      set
      {
        __isset.attributes = true;
        this._attributes = value;
      }
    }

    public int UpdateSequenceNum
    {
      get
      {
        return _updateSequenceNum;
      }
      set
      {
        __isset.updateSequenceNum = true;
        this._updateSequenceNum = value;
      }
    }

    public Data AlternateData
    {
      get
      {
        return _alternateData;
      }
      set
      {
        __isset.alternateData = true;
        this._alternateData = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool guid;
      public bool noteGuid;
      public bool data;
      public bool mime;
      public bool width;
      public bool height;
      public bool duration;
      public bool active;
      public bool recognition;
      public bool attributes;
      public bool updateSequenceNum;
      public bool alternateData;
    }

    public Resource() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              Guid = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              NoteGuid = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Data = new Data();
              Data.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              Mime = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.I16) {
              Width = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.I16) {
              Height = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.I16) {
              Duration = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Bool) {
              Active = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Struct) {
              Recognition = new Data();
              Recognition.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.Struct) {
              Attributes = new ResourceAttributes();
              Attributes.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I32) {
              UpdateSequenceNum = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.Struct) {
              AlternateData = new Data();
              AlternateData.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("Resource");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Guid != null && __isset.guid) {
        field.Name = "guid";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Guid);
        oprot.WriteFieldEnd();
      }
      if (NoteGuid != null && __isset.noteGuid) {
        field.Name = "noteGuid";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(NoteGuid);
        oprot.WriteFieldEnd();
      }
      if (Data != null && __isset.data) {
        field.Name = "data";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        Data.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Mime != null && __isset.mime) {
        field.Name = "mime";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Mime);
        oprot.WriteFieldEnd();
      }
      if (__isset.width) {
        field.Name = "width";
        field.Type = TType.I16;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(Width);
        oprot.WriteFieldEnd();
      }
      if (__isset.height) {
        field.Name = "height";
        field.Type = TType.I16;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(Height);
        oprot.WriteFieldEnd();
      }
      if (__isset.duration) {
        field.Name = "duration";
        field.Type = TType.I16;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(Duration);
        oprot.WriteFieldEnd();
      }
      if (__isset.active) {
        field.Name = "active";
        field.Type = TType.Bool;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Active);
        oprot.WriteFieldEnd();
      }
      if (Recognition != null && __isset.recognition) {
        field.Name = "recognition";
        field.Type = TType.Struct;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        Recognition.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Attributes != null && __isset.attributes) {
        field.Name = "attributes";
        field.Type = TType.Struct;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        Attributes.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.updateSequenceNum) {
        field.Name = "updateSequenceNum";
        field.Type = TType.I32;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UpdateSequenceNum);
        oprot.WriteFieldEnd();
      }
      if (AlternateData != null && __isset.alternateData) {
        field.Name = "alternateData";
        field.Type = TType.Struct;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        AlternateData.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Resource(");
      sb.Append("Guid: ");
      sb.Append(Guid);
      sb.Append(",NoteGuid: ");
      sb.Append(NoteGuid);
      sb.Append(",Data: ");
      sb.Append(Data== null ? "<null>" : Data.ToString());
      sb.Append(",Mime: ");
      sb.Append(Mime);
      sb.Append(",Width: ");
      sb.Append(Width);
      sb.Append(",Height: ");
      sb.Append(Height);
      sb.Append(",Duration: ");
      sb.Append(Duration);
      sb.Append(",Active: ");
      sb.Append(Active);
      sb.Append(",Recognition: ");
      sb.Append(Recognition== null ? "<null>" : Recognition.ToString());
      sb.Append(",Attributes: ");
      sb.Append(Attributes== null ? "<null>" : Attributes.ToString());
      sb.Append(",UpdateSequenceNum: ");
      sb.Append(UpdateSequenceNum);
      sb.Append(",AlternateData: ");
      sb.Append(AlternateData== null ? "<null>" : AlternateData.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
