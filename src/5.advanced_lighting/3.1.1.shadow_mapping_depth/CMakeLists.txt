cmake_minimum_required(VERSION 3.16)

project(3.1.1.shadow_mapping_depth)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} shadow_mapping_depth.cpp)
target_link_libraries(${TARGET} PUBLIC
        learnopengl
        glad
        glfw
        stb
        glm
        )
