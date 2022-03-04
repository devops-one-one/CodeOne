pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  stages{
    stage("Build Backend"){
      steps{
        sh "dotnet build GymOneBackend/GymOneBackend.sln"
      }
    }
        stage("Build Frontend"){
      steps{
        sh "ng build gym-one-fr/src"
      }
    }
  }
}
