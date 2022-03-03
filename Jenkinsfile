pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  stages{
    stage("Build Backend"){
      steps{
        sh "dotnet build GymOneBackend.sln"
      }
    }
  }
}
