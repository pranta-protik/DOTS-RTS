using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct UnitMoverSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state) {
        foreach (var (localTransform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>()) {
            localTransform.ValueRW.Position = localTransform.ValueRO.Position + new float3(moveSpeed.ValueRO.value, 0f, 0f) * SystemAPI.Time.DeltaTime;
        }
    }
}