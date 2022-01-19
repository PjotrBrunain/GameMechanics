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

	//Tried adding automatic labeling but couldn't get it to work

	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	TArray<UStaticMeshComponent*> m_pUnlockingIcons{};
	//
	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	UStaticMeshComponent* m_pUnlockingIcon {};
	//
	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	FVector m_pLabelOffSet {};
	//UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
	//	UStaticMesh* m_pPlaneMesh{};

	float m_AccuTime{};
	
public:	
	// Called every frame
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

	bool GetIsUnlocked();

	UFUNCTION(CallInEditor, Category = Attributes)
		void UpdateUnlockables();
};
