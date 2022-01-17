// Fill out your copyright notice in the Description page of Project Settings.


#include "UnlockingComponent.h"
#include <string>

// Sets default values for this component's properties
UUnlockingComponent::UUnlockingComponent()
{
	// Set this component to be initialized when the game starts, and to be ticked every frame.  You can turn these features
	// off to improve performance if you don't need them.
	PrimaryComponentTick.bCanEverTick = true;
	//static ConstructorHelpers::FObjectFinder<UStaticMesh>MeshAsset(TEXT("StaticMesh'/Game/Meshes/Plane.Plane'"));
	//m_pPlaneMesh = MeshAsset.Object;
	// ...
}

// Called when the game starts
void UUnlockingComponent::BeginPlay()
{
	Super::BeginPlay();

	// ...
	UpdateUnlockables();
}


// Called every frame
void UUnlockingComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	// ...
	m_AccuTime += DeltaTime;

	if (m_AccuTime >= m_UpdateTime)
	{
		bool unlocked{ true };
		for (auto actor : m_pUnlockingActors)
		{
			unlocked = unlocked && actor->GetUnlocked();
		}
		m_IsUnlocked = unlocked;
		m_AccuTime = 0;
	}
}

bool UUnlockingComponent::GetIsUnlocked()
{
	return m_IsUnlocked;
}

void UUnlockingComponent::UpdateUnlockables()
{
	//m_pUnlockingIcons.Empty();
	int i{};
	bool unlocked{ true };
	for (auto actor : m_pUnlockingActors)
	{
		unlocked = unlocked && actor->GetUnlocked();
		//UStaticMeshComponent* meshComponent = NewObject<UStaticMeshComponent>();
		//meshComponent->AttachToComponent(this, FAttachmentTransformRules::SnapToTargetIncludingScale);
		//meshComponent->SetRelativeLocation({ i * m_pLabelOffSet.X, m_pLabelOffSet.Y,m_pLabelOffSet.Z });
		//meshComponent->SetStaticMesh(m_pPlaneMesh);
		//m_pUnlockingIcons.Add(meshComponent);

		i++;
	}
	m_IsUnlocked = unlocked;
}