DOTNET := dotnet

help:
	@printf "Usage: make [target] [VARIABLE=value]\nTargets:\n"
	@grep -hE '^[a-zA-Z0-9_-]+:.*?## .*$$' $(MAKEFILE_LIST) \
	| awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-40s\033[0m %s\n", $$1, $$2}'

restore: ## Restore NuGet dependencies
	@$(DOTNET) restore

build: ## Build all projects (Debug)
	@$(DOTNET) build --no-restore

build-release: ## Build all projects (Release)
	@$(DOTNET) build --no-restore --configuration Release

test: ## Run all tests
	@$(DOTNET) test --no-build --verbosity normal

test-release: ## Run all tests in Release configuration
	@$(DOTNET) test --no-build --configuration Release --verbosity normal

lint: ## Check formatting and style (fails if anything needs changing)
	@$(DOTNET) format --verify-no-changes --severity warn

format: ## Auto-fix formatting and style issues
	@$(DOTNET) format --severity warn

run: ## Run the console app — usage: make run ARGS="<mu> <sigmaSquared> <x>"
	@$(DOTNET) run --project Distributions.Console -- $(ARGS)

benchmark: ## Run BenchmarkDotNet benchmarks (Release build required)
	@$(DOTNET) run --project Distributions.Benchmarks --configuration Release

clean: ## Remove build artefacts
	@$(DOTNET) clean

.PHONY: help restore build build-release test test-release lint format run benchmark clean
