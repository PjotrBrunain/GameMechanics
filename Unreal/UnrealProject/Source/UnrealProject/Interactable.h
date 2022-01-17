// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "InteractInterface.h"
#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
//#include "Delegates/Delegate.h"

class UWidgetComponent;
class UStaticMeshComponent;
class UUnlockingComponent;
//DECLARE_MULTICAST_DELEGATE(FActivated);
//DECLARE_MULTICAST_DELEGATE(FActivated);
//DECLARE_DYNAMIC_DELEGATE(FActivated);

#include "Interactable.generated.h"

UCLASS(BlueprintType, BluePrintable)
class UNREALPROJECT_API AInteractable : public AActor, public IInteractInterface
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AInteractable();
protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	bool m_IsActive{};

	//UPROPERTY(BlueprintAssignable, Category = ActivatedEvent)
	//	FActivated m_Activated{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes, meta=(DisplayName="WidgetLocation"))
		FVector m_WidgetLocation {};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes, meta = (DisplayName = "EnabledWidget"))
		UWidgetComponent* m_pEnabledWidget{};
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes, meta = (DisplayName = "DisabledWidget"))
		UWidgetComponent* m_pDisabledWiget{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = UnlockingComponent, meta = (DisplayName = "UnlockingComponent"))
		UUnlockingComponent* m_pUnlockingComponent {};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes, meta = (DisplayName = "StaticMesh"))
		UStaticMeshComponent* m_pStaticMesh {};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = WidgetAttributes, meta = (DisplayName = "WidgetEnabled"))
		bool m_WidgetEnabled{true};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Interactable, meta = (DisplayName = "InteractableDisabled"))
		bool m_Disabled{};

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Interactable, meta = (DisplayName = "IsUnlocked"))
		bool m_Unlocked{};
public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
	void ShowWidget_Implementation() override;
	void HideWidget_Implementation() override;
	
	bool GetUnlocked() const;

	UFUNCTION(BlueprintCallable, Category = Game)
		void Activate();

	UFUNCTION(BlueprintNativeEvent, Category = Game)
		void RunActivate();
};
