// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "Components/WidgetComponent.h"
#include "InteractInterface.h"
#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Interactable.generated.h"

UCLASS()
class UNREALPROJECT_API AInteractable : public AActor, public IInteractInterface
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AInteractable();

	void Activate();

	

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;



	bool m_IsActive{};
	DECLARE_DELEGATE(Activated);
	Activated m_Activated{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes)
		FVector m_WidgetLocation {};

	UWidgetComponent* m_pEnabledWidget{};
	UWidgetComponent* m_pDisabledWiget{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes)
		bool m_WidgetEnabled{true};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Interactable)
		bool m_Disabled{};
public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
	virtual void ShowWidget() override;
	virtual void HideWidget() override;
};
