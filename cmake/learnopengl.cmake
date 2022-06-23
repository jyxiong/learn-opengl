file(GLOB learnopengl_sources CONFIGURE_DEPENDS ${CMAKE_SOURCE_DIR}/includes/learnopengl/*.h)

add_library(learnopengl INTERFACE ${learnopengl_sources})
target_link_libraries(learnopengl INTERFACE glad assimp)
target_include_directories(learnopengl INTERFACE ${CMAKE_SOURCE_DIR}/includes)