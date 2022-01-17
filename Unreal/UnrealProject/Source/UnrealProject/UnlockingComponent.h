// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "Interactable.h"
#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "UnlockingComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class UNREALPROJECT_API UUnlockingComponent : public UPrimitiveComponent
{
	GENERATED_BODY()

public:	
	// Sets default values for this component's properties
	UUnlockingComponent();

protected:
	// Called when the game starts
	virtual void BeginPlay() override;

	UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = Attributes, meta = (DisplayName = "IsUnlocked"))
		bool m_IsUnlocked{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes, meta = (DisplayName = "UnlockingActors"))
		TArray<AInteractable*> m_pUnlockingActors{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes, meta = (DisplayName = "UpdateTime"))
		float m_UpdateTime{};

	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	TArray<UStaticMeshComponent*> m_pUnlockingIcons{};
	//
	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	UStaticMeshComponent* m_pUnlockingIcon {};
	//
	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	FVector m_pLabelOffSet {};

	float m_AccuTime{};

	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	UStaticMesh* m_pPlaneMesh{};

public:	
	// Called every frame
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

	bool GetIsUnlocked();

	UFUNCTION(CallInEditor, Category = Attributes)
		void UpdateUnlockables();
};
