# Todo #

This page is structured into open and accepted tasks. The open tasks are open for grabs by any eager contributor while the accepted ones are the tasks for which someone has assumed responsibility.

## Open Task List ##

This section contains the open task list with planned development tasks. This list should _not_ be interpreted as a complete list of remaining work, but more a guide for those who want to contribute without the hassle of finding tasks on their own. The tasks should represent logical groupings, but the can be separated into smaller tasks if desirable.

### Documentation ###

  * We need to start a proper documentation. The most obvious solution would be to integrate it with the monodoc project, but we need to figure out our possibilities.
  * The web page needs more information about what MonoXNA is besides the fact that we aim to be an open source replacement of MS XNA

### NUNIT Tests ###

  * Most of the tests are successful, but the ones that are not need to be fixed.
  * Many of the tests use TestHelper.ApproximatelyEqual() to test the values. This method should be revised to allow better control.

### Framework compatibility with XNA 3.1 ###

  * We need to check the public API to make sure it matches MS XNA 3.1

### Microsoft.Xna.Framework.Graphics Namespace ###

  * Improve GraphicsDevice
    1. `public void Clear(ClearOptions options, Color color, float depth, int stencil)`
    1. `public void DrawPrimitives(PrimitiveType primitiveType, int startVertex, int primitiveCount)`
    1. `public void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount)`
  * Improve GraphicsAdapter and Improve GraphicsDeviceManager
  * Improve Matrix
    1. `public static Matrix CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float zNearPlane, float zFarPlane)`
  * Implement VertexBuffer, IndexBuffer and VertexDeclaration
  * Implement Effect
    1. `public void Begin() {}`
    1. `public void End() {}`
    1. `public EffectTechnique CurrentTechnique { get {} set {} }`
    1. `public void CommitChanges() {}`
  * Implement BasicEffect
    1. `public VertexPositionColor(Vector3 position, Color color) {}`
  * Implement EffectParameter
    1. `public Matrix GetValueMatrix() {}`
    1. `public Vector3 GetValueVector3() {}`
  * Implement EffectPass
    1. `public void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount)`
    1. `public sealed class EffectPass {}`
  * EffectTechnique
    1. `public EffectPassCollection Passes  get {}`
  * Implement classes: Model, ModelBone, ModelBoneCollection, ModelEffectCollection, ModelMesh, ModelMeshCollection, ModelMeshPart and ModelMeshPartCollection

### Microsoft.Xna.Framework.Content Namespace ###

  * Update classes: ContentManager and ContentReader

### Microsoft.Xna.Framework.Content.Pipeline Namespace ###

  * Implement OpaqueDataDictionary class
  * Implement XmlImporter class

### Content Importers ###

  * Implement Microsoft.Xna.Framework.Content.Pipeline.AudioImporters namespace
  * Implement Microsoft.Xna.Framework.Content.Pipeline.EffectImporter namespace
  * Implement Microsoft.Xna.Framework.Content.Pipeline.XImporter namespace