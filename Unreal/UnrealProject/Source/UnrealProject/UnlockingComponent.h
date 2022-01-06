// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "Interactable.h"
#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "UnlockingComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class UNREALPROJECT_API UUnlockingComponent : public UActorComponent
{
	GENERATED_BODY()

public:	
	// Sets default values for this component's properties
	UUnlockingComponent();

protected:
	// Called when the game starts
	virtual void BeginPlay() override;

	UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = Attributes)
		bool m_IsUnlocked{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Attributes)
		TArray<AInteractable*> m_pUnlockingActors{};

public:	
	// Called every frame
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

		
};
