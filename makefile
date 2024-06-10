# Used by `image`, `push` & `deploy` targets, override as required
IMAGE_REG ?= docker.io
IMAGE_REPO ?= tselloss/actyin
IMAGE_TAG ?= latest

# Used by `test-api` target
TEST_HOST ?= localhost:5000

# Don't change
SRC_DIR := ActyIn
TEST_DIR := AthletesTests

.PHONY: help lint lint-fix image push run deploy undeploy test test-report test-api clean .EXPORT_ALL_VARIABLES
.DEFAULT_GOAL := help

help: ## 💬 This help message
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-20s\033[0m %s\n", $$1, $$2}'

lint: ## 🔎 Lint & format, will not fix but sets exit code on error 
	@dotnet format --help > /dev/null 2> /dev/null || dotnet tool install --global dotnet-format
	dotnet format --verbosity diag ./src

image: ## 🔨 Build container image from Dockerfile 
	docker build . --file ActyIn/Dockerfile \
	--tag $(IMAGE_REG)/$(IMAGE_REPO):$(IMAGE_TAG)

push: ## 📤 Push container image to registry 
	docker push $(IMAGE_REG)/$(IMAGE_REPO):$(IMAGE_TAG)

run: ## 🏃‍ Run locally using Dotnet CLI
	dotnet watch --project $(SRC_DIR)/ActyIn.csproj

test: ## 🎯 Unit tests with xUnit
	dotnet test tests/tests.csproj 

test-report: ## 🤡 Unit tests with xUnit & output report
	rm -rf $(TEST_DIR)/TestResults
	dotnet test $(TEST_DIR)/tests.csproj --test-adapter-path:. --logger:junit --logger:html

test-api: .EXPORT_ALL_VARIABLES ##🚦 Run integration API tests, server must be running!
	cd tests \
	&& npm install newman \
	&& ./node_modules/.bin/newman run ./postman_collection.json --env-var apphost=$(TEST_HOST)

clean: ## 🧹 Clean up project
	rm -rf $(TEST_DIR)/node_modules
	rm -rf $(TEST_DIR)/package*
	rm -rf $(TEST_DIR)/TestResults
	rm -rf $(TEST_DIR)/bin
	rm -rf $(TEST_DIR)/obj
	rm -rf $(SRC_DIR)/bin
	rm -rf $(SRC_DIR)/obj
