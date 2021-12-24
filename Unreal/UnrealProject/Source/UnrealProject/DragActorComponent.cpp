//for // Fill out your copyright notice in the Description page of Project Settings.


#include "DragActorComponent.h"
#include "Kismet/GameplayStatics.h"

// Sets default values for this component's properties
UDragActorComponent::UDragActorComponent()
{
	// Set this component to be initialized when the game starts, and to be ticked every frame.  You can turn these features
	// off to improve performance if you don't need them.
	PrimaryComponentTick.bCanEverTick = true;

	// ...
}


// Called when the game starts
void UDragActorComponent::BeginPlay()
{
	Super::BeginPlay();

	// ...
	
}


// Called every frame
void UDragActorComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	if (m_Dragging)
	{
		auto pawn = GetWorld()->GetFirstPlayerController()->GetPawn();
		GetOwner()->SetActorLocation(pawn->GetActorLocation() + pawn->GetActorForwardVector() * m_DragOffset.Y + pawn->GetActorRightVector() * m_DragOffset.X + pawn->GetActorUpVector() * m_DragOffset.Z);
	}
	// ...
}

