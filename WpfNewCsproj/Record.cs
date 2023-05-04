namespace WpfNewCsproj;

// Recordも使用可能(InternalReservedAttributeGenerator の IsExternalInit のおかげ)
// 旧csprojはソースジェネレータが動作しないせいでパッケージを導入してもビルドできなかった
public record Record(int Value);
