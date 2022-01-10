// Fill out your copyright notice in the Description page of Project Settings.


#include "Interactable.h"
#include "Components/StaticMeshComponent.h"
#include "Components/WidgetComponent.h"
#include "UnlockingComponent.h"

// Sets default values
AInteractable::AInteractable()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	UStaticMeshComponent* staticMesh = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("StaticMesh"));
	staticMesh->AttachToComponent(RootComponent, FAttachmentTransformRules::KeepRelativeTransform);
	m_pStaticMesh = staticMesh;
	m_pStaticMesh->SetCollisionProfileName(TEXT("Interactable"));

	
	UWidgetComponent* widget = CreateDefaultSubobject<UWidgetComponent>(TEXT("Widget"));
	widget->AttachToComponent(staticMesh, FAttachmentTransformRules::KeepRelativeTransform);
	widget->SetRelativeLocation(FVector{ 0.f,0.f,80.f });
	m_pEnabledWidget = widget;
	widget = CreateDefaultSubobject<UWidgetComponent>(TEXT("WidgetDisabled"));
	widget->AttachToComponent(staticMesh, FAttachmentTransformRules::KeepRelativeTransform);
	widget->SetRelativeLocation(FVector{ 0.f,0.f,80.f });
	m_pDisabledWiget = widget;

	m_pEnabledWidget->SetVisibility(false);
	m_pDisabledWiget->SetVisibility(false);

	m_pUnlockingComponent = CreateDefaultSubobject<UUnlockingComponent>(TEXT("UnlockingComponent"));
}

void AInteractable::Activate()
{
	if (m_Disabled) return;

	m_IsActive = !m_IsActive;

	RunActivate();
}

// Called when the game starts or when spawned
void AInteractable::BeginPlay()
{
	Super::BeginPlay();

	//m_pEnabledWidget = CreateDefaultSubobject<UWidgetComponent>(TEXT("EnabledWidget"));
	//m_pDisabledWiget = CreateDefaultSubobject<UWidgetComponent>(TEXT("DisabledWidget"));

	m_pEnabledWidget->SetRelativeLocation(m_WidgetLocation);
	m_pDisabledWiget->SetRelativeLocation(m_WidgetLocation);

	m_Disabled = !m_pUnlockingComponent->GetIsUnlocked();

}

// Called every frame
void AInteractable::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	m_Disabled = !m_pUnlockingComponent->GetIsUnlocked();
}

void AInteractable::RunActivate_Implementation() 
{

}

void AInteractable::ShowWidget_Implementation()
{
	if (!m_WidgetEnabled) return;

	if (m_Disabled)
	{
		m_pDisabledWiget->SetVisibility(true);
	}
	else
	{
		m_pEnabledWidget->SetVisibility(true);
	}
}

void AInteractable::HideWidget_Implementation()
{
	m_pDisabledWiget->SetVisibility(false);
	m_pEnabledWidget->SetVisibility(false);
}

bool AInteractable::GetUnlocked() const
{
	return m_Unlocked;
}

