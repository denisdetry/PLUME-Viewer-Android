// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: plume/sample/unity/terrain_collider.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PLUME.Sample.Unity {

  /// <summary>Holder for reflection information generated from plume/sample/unity/terrain_collider.proto</summary>
  public static partial class TerrainColliderReflection {

    #region Descriptor
    /// <summary>File descriptor for plume/sample/unity/terrain_collider.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TerrainColliderReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CilwbHVtZS9zYW1wbGUvdW5pdHkvdGVycmFpbl9jb2xsaWRlci5wcm90bxIS",
            "cGx1bWUuc2FtcGxlLnVuaXR5GiRwbHVtZS9zYW1wbGUvdW5pdHkvaWRlbnRp",
            "ZmllcnMucHJvdG8iXgoVVGVycmFpbkNvbGxpZGVyQ3JlYXRlEkUKCWNvbXBv",
            "bmVudBgBIAEoCzInLnBsdW1lLnNhbXBsZS51bml0eS5Db21wb25lbnRJZGVu",
            "dGlmaWVyUgljb21wb25lbnQiXwoWVGVycmFpbkNvbGxpZGVyRGVzdHJveRJF",
            "Cgljb21wb25lbnQYASABKAsyJy5wbHVtZS5zYW1wbGUudW5pdHkuQ29tcG9u",
            "ZW50SWRlbnRpZmllclIJY29tcG9uZW50IroCChVUZXJyYWluQ29sbGlkZXJV",
            "cGRhdGUSRQoJY29tcG9uZW50GAEgASgLMicucGx1bWUuc2FtcGxlLnVuaXR5",
            "LkNvbXBvbmVudElkZW50aWZpZXJSCWNvbXBvbmVudBIdCgdlbmFibGVkGAIg",
            "ASgISABSB2VuYWJsZWSIAQESSwoMdGVycmFpbl9kYXRhGAMgASgLMiMucGx1",
            "bWUuc2FtcGxlLnVuaXR5LkFzc2V0SWRlbnRpZmllckgBUgt0ZXJyYWluRGF0",
            "YYgBARJECghtYXRlcmlhbBgEIAEoCzIjLnBsdW1lLnNhbXBsZS51bml0eS5B",
            "c3NldElkZW50aWZpZXJIAlIIbWF0ZXJpYWyIAQFCCgoIX2VuYWJsZWRCDwoN",
            "X3RlcnJhaW5fZGF0YUILCglfbWF0ZXJpYWxCFaoCElBMVU1FLlNhbXBsZS5V",
            "bml0eWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::PLUME.Sample.Unity.IdentifiersReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PLUME.Sample.Unity.TerrainColliderCreate), global::PLUME.Sample.Unity.TerrainColliderCreate.Parser, new[]{ "Component" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PLUME.Sample.Unity.TerrainColliderDestroy), global::PLUME.Sample.Unity.TerrainColliderDestroy.Parser, new[]{ "Component" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PLUME.Sample.Unity.TerrainColliderUpdate), global::PLUME.Sample.Unity.TerrainColliderUpdate.Parser, new[]{ "Component", "Enabled", "TerrainData", "Material" }, new[]{ "Enabled", "TerrainData", "Material" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class TerrainColliderCreate : pb::IMessage<TerrainColliderCreate>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TerrainColliderCreate> _parser = new pb::MessageParser<TerrainColliderCreate>(() => new TerrainColliderCreate());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TerrainColliderCreate> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PLUME.Sample.Unity.TerrainColliderReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderCreate() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderCreate(TerrainColliderCreate other) : this() {
      component_ = other.component_ != null ? other.component_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderCreate Clone() {
      return new TerrainColliderCreate(this);
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 1;
    private global::PLUME.Sample.Unity.ComponentIdentifier component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.ComponentIdentifier Component {
      get { return component_; }
      set {
        component_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TerrainColliderCreate);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TerrainColliderCreate other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Component, other.Component)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (component_ != null) hash ^= Component.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (component_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Component);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TerrainColliderCreate other) {
      if (other == null) {
        return;
      }
      if (other.component_ != null) {
        if (component_ == null) {
          Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
        }
        Component.MergeFrom(other.Component);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class TerrainColliderDestroy : pb::IMessage<TerrainColliderDestroy>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TerrainColliderDestroy> _parser = new pb::MessageParser<TerrainColliderDestroy>(() => new TerrainColliderDestroy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TerrainColliderDestroy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PLUME.Sample.Unity.TerrainColliderReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderDestroy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderDestroy(TerrainColliderDestroy other) : this() {
      component_ = other.component_ != null ? other.component_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderDestroy Clone() {
      return new TerrainColliderDestroy(this);
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 1;
    private global::PLUME.Sample.Unity.ComponentIdentifier component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.ComponentIdentifier Component {
      get { return component_; }
      set {
        component_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TerrainColliderDestroy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TerrainColliderDestroy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Component, other.Component)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (component_ != null) hash ^= Component.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (component_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Component);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TerrainColliderDestroy other) {
      if (other == null) {
        return;
      }
      if (other.component_ != null) {
        if (component_ == null) {
          Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
        }
        Component.MergeFrom(other.Component);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class TerrainColliderUpdate : pb::IMessage<TerrainColliderUpdate>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TerrainColliderUpdate> _parser = new pb::MessageParser<TerrainColliderUpdate>(() => new TerrainColliderUpdate());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TerrainColliderUpdate> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PLUME.Sample.Unity.TerrainColliderReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderUpdate() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderUpdate(TerrainColliderUpdate other) : this() {
      _hasBits0 = other._hasBits0;
      component_ = other.component_ != null ? other.component_.Clone() : null;
      enabled_ = other.enabled_;
      terrainData_ = other.terrainData_ != null ? other.terrainData_.Clone() : null;
      material_ = other.material_ != null ? other.material_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TerrainColliderUpdate Clone() {
      return new TerrainColliderUpdate(this);
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 1;
    private global::PLUME.Sample.Unity.ComponentIdentifier component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.ComponentIdentifier Component {
      get { return component_; }
      set {
        component_ = value;
      }
    }

    /// <summary>Field number for the "enabled" field.</summary>
    public const int EnabledFieldNumber = 2;
    private readonly static bool EnabledDefaultValue = false;

    private bool enabled_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Enabled {
      get { if ((_hasBits0 & 1) != 0) { return enabled_; } else { return EnabledDefaultValue; } }
      set {
        _hasBits0 |= 1;
        enabled_ = value;
      }
    }
    /// <summary>Gets whether the "enabled" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasEnabled {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "enabled" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearEnabled() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "terrain_data" field.</summary>
    public const int TerrainDataFieldNumber = 3;
    private global::PLUME.Sample.Unity.AssetIdentifier terrainData_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.AssetIdentifier TerrainData {
      get { return terrainData_; }
      set {
        terrainData_ = value;
      }
    }

    /// <summary>Field number for the "material" field.</summary>
    public const int MaterialFieldNumber = 4;
    private global::PLUME.Sample.Unity.AssetIdentifier material_;
    /// <summary>
    /// Physic material of the terrain (friction, bounciness)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.AssetIdentifier Material {
      get { return material_; }
      set {
        material_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TerrainColliderUpdate);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TerrainColliderUpdate other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Component, other.Component)) return false;
      if (Enabled != other.Enabled) return false;
      if (!object.Equals(TerrainData, other.TerrainData)) return false;
      if (!object.Equals(Material, other.Material)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (component_ != null) hash ^= Component.GetHashCode();
      if (HasEnabled) hash ^= Enabled.GetHashCode();
      if (terrainData_ != null) hash ^= TerrainData.GetHashCode();
      if (material_ != null) hash ^= Material.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (HasEnabled) {
        output.WriteRawTag(16);
        output.WriteBool(Enabled);
      }
      if (terrainData_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(TerrainData);
      }
      if (material_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Material);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (HasEnabled) {
        output.WriteRawTag(16);
        output.WriteBool(Enabled);
      }
      if (terrainData_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(TerrainData);
      }
      if (material_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Material);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (component_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Component);
      }
      if (HasEnabled) {
        size += 1 + 1;
      }
      if (terrainData_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(TerrainData);
      }
      if (material_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Material);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TerrainColliderUpdate other) {
      if (other == null) {
        return;
      }
      if (other.component_ != null) {
        if (component_ == null) {
          Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
        }
        Component.MergeFrom(other.Component);
      }
      if (other.HasEnabled) {
        Enabled = other.Enabled;
      }
      if (other.terrainData_ != null) {
        if (terrainData_ == null) {
          TerrainData = new global::PLUME.Sample.Unity.AssetIdentifier();
        }
        TerrainData.MergeFrom(other.TerrainData);
      }
      if (other.material_ != null) {
        if (material_ == null) {
          Material = new global::PLUME.Sample.Unity.AssetIdentifier();
        }
        Material.MergeFrom(other.Material);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
          case 16: {
            Enabled = input.ReadBool();
            break;
          }
          case 26: {
            if (terrainData_ == null) {
              TerrainData = new global::PLUME.Sample.Unity.AssetIdentifier();
            }
            input.ReadMessage(TerrainData);
            break;
          }
          case 34: {
            if (material_ == null) {
              Material = new global::PLUME.Sample.Unity.AssetIdentifier();
            }
            input.ReadMessage(Material);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
          case 16: {
            Enabled = input.ReadBool();
            break;
          }
          case 26: {
            if (terrainData_ == null) {
              TerrainData = new global::PLUME.Sample.Unity.AssetIdentifier();
            }
            input.ReadMessage(TerrainData);
            break;
          }
          case 34: {
            if (material_ == null) {
              Material = new global::PLUME.Sample.Unity.AssetIdentifier();
            }
            input.ReadMessage(Material);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
